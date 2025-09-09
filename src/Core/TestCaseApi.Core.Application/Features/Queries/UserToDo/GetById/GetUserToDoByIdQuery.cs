using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;

namespace TestCaseApi.Core.Application.Features.Queries.UserToDo.GetById;

public class GetUserToDoByIdQuery:IRequest<HandlerResult<Domain.Models.UserToDo>>
{
    public Guid Id { get; set; }

    public GetUserToDoByIdQuery(Guid id)
    {
        Id = id;
    }
}
