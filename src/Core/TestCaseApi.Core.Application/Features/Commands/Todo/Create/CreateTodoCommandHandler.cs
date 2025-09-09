using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Features.Commands.Todo.Create;

public class CreateTodoCommandHandler:IRequestHandler<CreateTodoCommand, HandlerResult<Domain.Models.ToDo>>
{
    protected readonly ITodoRepository _todoRepository;

    public CreateTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<HandlerResult<Domain.Models.ToDo>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _todoRepository.AddAsyncWithReturn(new Domain.Models.ToDo()
            {
                Title = request.Title,
                Description = request.Description,
                Tag = request.Tag,
                Start = request.Start,
            });

            return HandlerResult.Ok(result);
        }
        catch (Exception ex)
        {
            return HandlerResult.Fail<ToDo>(ex.Message);
        }
    }
}
