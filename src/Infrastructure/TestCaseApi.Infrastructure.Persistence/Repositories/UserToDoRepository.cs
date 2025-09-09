using Microsoft.EntityFrameworkCore;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;
using TestCaseApi.Infrastructure.Persistence.Context;

namespace TestCaseApi.Infrastructure.Persistence.Repositories;
public class UserToDoRepository : GenericRepository<UserToDo>, IUserToDoRepository
{
    public UserToDoRepository(TestCaseDbContext dbContext) : base(dbContext)
    {
    }
}
