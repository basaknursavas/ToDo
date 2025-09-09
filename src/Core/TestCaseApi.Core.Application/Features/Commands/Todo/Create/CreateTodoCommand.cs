using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Features.Commands.Todo.Create;

public class CreateTodoCommand:IRequest<HandlerResult<ToDo>>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tag   { get; set; }
    public DateTime Start { get; set; }

    public CreateTodoCommand(string title, string description, DateTime start)
    {
        Title = title;
        Description = description;
        Start = start;
    }
}
