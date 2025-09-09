
using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
namespace TestCaseApi.Core.Application.Features.Commands.UserToDo.Insert;

public class InsertUserToDoCommand :IRequest<HandlerResult<int>>
{
    public required Guid UserId { get; set; }
    public required Guid ToDoId { get; set; }
}
