using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;

namespace TestCaseApi.Core.Application.Features.Commands.Todo.Update;

public class UpdateTodoCommandHandler:IRequestHandler<UpdateTodoCommand, HandlerResult<int>>
{
    protected readonly ITodoRepository _todoRepository;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<HandlerResult<int>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var exist = await _todoRepository.GetByIdAsync(request.Id);
            if (exist == null)
            {
                return HandlerResult.Fail<int>("Cannot find");
            }
            exist.Title = request.Title;
            exist.Description = request.Description;
            exist.Tag = request.Tag;
            exist.Start = request.Start;
            exist.End= request.End;
            exist.Completed = request.Completed;
            var result = await _todoRepository.UpdateAsync(exist);
            return HandlerResult.Ok(result);
        }
        catch (Exception ex)
        {
            return HandlerResult.Fail<int>(ex.Message);
        }
    }
}
