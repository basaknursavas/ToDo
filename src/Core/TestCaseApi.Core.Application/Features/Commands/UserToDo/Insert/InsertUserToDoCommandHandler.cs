using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Features.Commands.UserToDo.Insert;

public class InsertUserToDoCommandHandler : IRequestHandler<InsertUserToDoCommand, HandlerResult<int>>
{
    private readonly IUserToDoRepository _repository;

    public InsertUserToDoCommandHandler(IUserToDoRepository repository)
    {
        _repository = repository;
    }

    public async Task<HandlerResult<int>> Handle(InsertUserToDoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var NewUserToDo = new Domain.Models.UserToDo()
            {
                UserId = request.UserId,
                ToDoId = request.ToDoId
            };
            var res = await _repository.AddAsync(NewUserToDo);
            return HandlerResult.Ok(res);
        }
        catch (Exception ex)
        {

            return HandlerResult.Fail<int>(ex.Message);
        }
    }
}
