using MediatR;

using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Features.Queries.User.GetAll
{
    public class GetAllUserQueryHandler:IRequestHandler<GetAllUserQuery, HandlerResult<List<Domain.Models.User>>>
    {
        protected readonly IUserRepository _userRepository;
        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<HandlerResult<List<Domain.Models.User>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userRepository.GetAll();
                return HandlerResult.Ok(result);
            }
            catch (Exception ex)
            {
                return HandlerResult.Fail<List<Domain.Models.User>>(ex.Message);
            }
        }


    }
}
