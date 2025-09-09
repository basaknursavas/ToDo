namespace TestCaseApi.Core.Domain.Models;

public class UserToDo : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ToDoId { get; set; }
}
