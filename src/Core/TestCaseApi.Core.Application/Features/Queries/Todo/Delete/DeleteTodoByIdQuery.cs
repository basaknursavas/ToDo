using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;

namespace TestCaseApi.Core.Application.Features.Queries.Todo.Delete;

public class DeleteTodoByIdQuery:IRequest<HandlerResult<int>>
{
    public Guid Id { get; set; }

    public DeleteTodoByIdQuery(Guid id)
    {
        Id = id;
    }
}
