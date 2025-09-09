using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Dtos;

namespace TestCaseApi.Core.Application.Features.Queries.User.GetUserToDos;

public class GetUserToDosQuery:IRequest<HandlerResult<UserTodoDto>>
{
    public Guid UserId { get; set; }

    public GetUserToDosQuery(Guid userId)
    {
        UserId = userId;
    }
}
