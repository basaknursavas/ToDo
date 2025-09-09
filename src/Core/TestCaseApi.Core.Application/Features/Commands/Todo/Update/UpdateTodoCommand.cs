using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;

namespace TestCaseApi.Core.Application.Features.Commands.Todo.Update;

public class UpdateTodoCommand:IRequest<HandlerResult<int>>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tag   { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool Completed { get; set; }

}
