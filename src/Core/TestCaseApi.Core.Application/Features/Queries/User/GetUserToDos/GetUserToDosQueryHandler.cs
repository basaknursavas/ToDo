using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Dtos;
using TestCaseApi.Core.Application.Interfaces;

namespace TestCaseApi.Core.Application.Features.Queries.User.GetUserToDos;

public class GetUserToDosQueryHandler : IRequestHandler<GetUserToDosQuery, HandlerResult<UserTodoDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITodoRepository _todoRepository;
    private readonly IUserToDoRepository _userToDoRepository;

    public GetUserToDosQueryHandler(IUserRepository userRepository, ITodoRepository todoRepository, IUserToDoRepository userToDoRepository)
    {
        _userRepository = userRepository;
        _todoRepository = todoRepository;
        _userToDoRepository = userToDoRepository;
    }

    public async Task<HandlerResult<UserTodoDto>> Handle(GetUserToDosQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var newResult = new UserTodoDto();
            var user = await _userRepository.GetByIdAsync(request.UserId);
            newResult.CurrentUser = user;



            var userTodoList = _userToDoRepository.AsQueryable().Where(x => x.UserId == request.UserId).ToList();

            
            newResult.ToDos = new List<Domain.Models.ToDo>();
            foreach (var item in userTodoList)
            {
                var one = await _todoRepository.GetByIdAsync(item.ToDoId);
                if (one != null)
                    newResult.ToDos.Add(one);
            }
            return HandlerResult.Ok(newResult);
        }
        catch (Exception ex)
        {
            return HandlerResult.Fail<UserTodoDto>(ex.Message);
        }
    }
}
