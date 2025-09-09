
using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;
using TestCaseApi.Common.SharedKernel.ReturnTypes;


namespace TestCaseApi.Core.Application.Features.Queries.UserToDo.GetAll;

public class GetAllUserToDoQueryHandler : IRequestHandler<GetAllUserToDoQuery, HandlerResult<List<Domain.Models.UserToDo>>>
{ 

    protected readonly IUserToDoRepository _userToDoRepository;

    public GetAllUserToDoQueryHandler(IUserToDoRepository userToDoRepository)
    {
        _userToDoRepository = userToDoRepository;
    }

    public async Task<HandlerResult<List<Domain.Models.UserToDo>>> Handle(GetAllUserToDoQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _userToDoRepository.GetAll();
            return HandlerResult.Ok(result);
        }
        catch (Exception ex)
        {
            return HandlerResult.Fail<List<Domain.Models.UserToDo>>(ex.Message);
        }
    }
}
