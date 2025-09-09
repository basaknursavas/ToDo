

using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;

namespace TestCaseApi.Core.Application.Features.Queries.Todo.Delete;

public class DeleteTodoByIdQueryHandler : IRequestHandler<DeleteTodoByIdQuery, HandlerResult<int>>
{
	protected readonly ITodoRepository _repository;

    public DeleteTodoByIdQueryHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<HandlerResult<int>> Handle(DeleteTodoByIdQuery request, CancellationToken cancellationToken)
    {
		try
		{
            var result = await _repository.DeleteAsync(request.Id);
            return HandlerResult.Ok(result);
		}
		catch (Exception ex)
		{
            return HandlerResult.Fail<int>(ex.Message);
		}
    }
}
