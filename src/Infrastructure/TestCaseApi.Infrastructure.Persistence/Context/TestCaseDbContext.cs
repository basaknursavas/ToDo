
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestCaseApi.Core.Domain.Models;
using TestCaseApi.Infrastructure.Persistence.Migrations;

namespace TestCaseApi.Infrastructure.Persistence.Context;

public class TestCaseDbContext : DbContext
{
    public TestCaseDbContext(DbContextOptions options) : base(options)
    {
        Database.Migrate();
    }
    public TestCaseDbContext()
    {
    }


    public DbSet<User> users { get; set; }
    public DbSet<ToDo> toDos { get; set; }
    public DbSet<UserToDo> userToDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = @"Data Source=YAYEGENC\SQLEXPRESS;Initial Catalog=testCaseDb;User Id=testUser;Password=Abc123!;Trust Server Certificate=True;";
            optionsBuilder.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }
    private void OnBeforeSave()
    {
        var AddedEntites = ChangeTracker.Entries()
                                        .Where(i => i.State == EntityState.Added)
                                        .Select(i => (BaseEntity)i.Entity);
        PreapareAddedEntities(AddedEntites);
    }

    private static void PreapareAddedEntities(IEnumerable<BaseEntity> entities)
    {
        foreach (var entity in entities)
        {
            //if (entity.Created != DateTime.MinValue)
            entity.Created = DateTime.Now;

            entity.Updated = DateTime.Now;
        }
    }

}
