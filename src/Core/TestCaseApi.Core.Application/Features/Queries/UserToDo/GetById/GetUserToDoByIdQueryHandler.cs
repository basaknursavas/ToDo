
using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;

namespace TestCaseApi.Core.Application.Features.Queries.UserToDo.GetById
{
    public class GetUserToDoByIdQueryHandler : IRequestHandler<GetUserToDoByIdQuery, HandlerResult<Domain.Models.UserToDo>>
    {
        protected readonly IUserToDoRepository _userToDoRepository;


        public GetUserToDoByIdQueryHandler(IUserToDoRepository userToDoRepository)
        {
           _userToDoRepository = userToDoRepository;

        }
        public async Task<HandlerResult<Domain.Models.UserToDo>> Handle(GetUserToDoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userToDoRepository.GetByIdAsync(request.Id);
                if (result == null)
                {

                    return HandlerResult.Fail<Domain.Models.UserToDo>("Not Found");
                }
                return HandlerResult.Ok(result);

            }
            catch (Exception ex)
            {
                return HandlerResult.Fail<Domain.Models.UserToDo>(ex.Message);
            }
        }
    }
}
