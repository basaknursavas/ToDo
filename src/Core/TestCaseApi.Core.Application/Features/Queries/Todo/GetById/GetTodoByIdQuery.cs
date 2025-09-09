using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Features.Queries.Todo.GetById;

public class GetTodoByIdQuery:IRequest<HandlerResult<ToDo>>
{
    public Guid Id { get; set; }

    public GetTodoByIdQuery(Guid id)
    {
        Id = id;
    }
}
