using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Dtos;

public class UserTodoDto
{
    public User CurrentUser { get; set; }
    public List<ToDo> ToDos { get; set; }
}
