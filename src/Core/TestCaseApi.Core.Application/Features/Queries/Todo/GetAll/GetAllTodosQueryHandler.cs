using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Features.Queries.Todo.GetAll;

public class GetAllTodosQueryHandler:IRequestHandler<GetAllTodosQuery,HandlerResult<List<ToDo>>>
{
    protected readonly ITodoRepository _todoRepository;

    public GetAllTodosQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<HandlerResult<List<ToDo>>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _todoRepository.GetAll();
            return HandlerResult.Ok(result);
        }
        catch (Exception ex)
        {
            return HandlerResult.Fail<List<ToDo>>(ex.Message);
        }
    }
}
