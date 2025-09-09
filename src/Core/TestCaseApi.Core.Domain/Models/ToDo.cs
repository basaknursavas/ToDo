namespace TestCaseApi.Core.Domain.Models;

public class ToDo:BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tag { get; set; }
    public DateTimeOffset Start { get; set; }
    public DateTimeOffset End { get; set; }
    public bool Completed { get; set; }

}
