using Microsoft.EntityFrameworkCore;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;
using TestCaseApi.Infrastructure.Persistence.Context;

namespace TestCaseApi.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(TestCaseDbContext dbContext) : base(dbContext)
    {
    }
}
