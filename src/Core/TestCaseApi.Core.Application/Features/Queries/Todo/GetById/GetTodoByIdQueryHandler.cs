using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Features.Queries.Todo.GetById;

public class GetTodoByIdQueryHandler:IRequestHandler<GetTodoByIdQuery,HandlerResult<ToDo>>
{
    protected readonly ITodoRepository _todoRepository;

    public GetTodoByIdQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<HandlerResult<ToDo>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _todoRepository.GetByIdAsync(request.Id);
            if (result == null)
            {
                return HandlerResult.Fail<ToDo>("Not Found");
            }
            return HandlerResult.Ok(result);
        }
        catch (Exception ex)
        {
            return HandlerResult.Fail<ToDo>(ex.Message);
        }
    }
}
