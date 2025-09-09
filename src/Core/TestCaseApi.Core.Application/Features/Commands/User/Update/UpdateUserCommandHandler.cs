using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;

namespace TestCaseApi.Core.Application.Features.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, HandlerResult<int>>
    {

        protected readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<HandlerResult<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var exist = await _userRepository.GetByIdAsync(request.Id); //fetch the User's data by id.
                if (exist == null)
                {
                    return HandlerResult.Fail<int>("Cannot find");
                }

                exist.Username = request.Username;
                exist.Email = request.Email;

                if(!String.IsNullOrWhiteSpace(request.Password)){
                    exist.Password = request.Password;
                }

                
                

                var result = await _userRepository.UpdateAsync(exist);
                return HandlerResult.Ok(result);
            }
            catch (Exception ex)
            {
                return HandlerResult.Fail<int>(ex.Message);
            }
        }



    }
    
}
