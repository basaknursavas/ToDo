using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Infrastructure.Persistence.Context;
using TestCaseApi.Infrastructure.Persistence.Repositories;

namespace TestCaseApi.Infrastructure.Persistence.Extension;
public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TestCaseDbContext>(conf =>
        {
            var connStr = configuration["TestCaseApiDb"].ToString();
            conf.UseSqlServer(connStr, opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });
        services.AddSingleton(configuration);
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<IUserToDoRepository, UserToDoRepository>();
        return services;
    }
}
