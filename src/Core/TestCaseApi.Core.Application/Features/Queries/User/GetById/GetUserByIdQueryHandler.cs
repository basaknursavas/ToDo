using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;
using TestCaseApi.Core.Domain.Models;


namespace TestCaseApi.Core.Application.Features.Queries.User.GetById
{
    public class GetUserByIdQueryHandler:IRequestHandler<GetUserByIdQuery, HandlerResult<Domain.Models.User>>
    {

        protected readonly IUserRepository _userRepository; 

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<HandlerResult<Domain.Models.User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            try
            {
                var result = await _userRepository.GetByIdAsync(request.Id);
                if (result == null) {

                    return HandlerResult.Fail<Domain.Models.User>("Not Found");
                }
                return HandlerResult.Ok(result);

            }
            catch (Exception ex) 
            {
                return HandlerResult.Fail<Domain.Models.User>(ex.Message);
            }

        }
    }
}
