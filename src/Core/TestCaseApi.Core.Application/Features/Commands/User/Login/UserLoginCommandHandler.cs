using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Dtos;
using TestCaseApi.Core.Application.Interfaces;

namespace TestCaseApi.Core.Application.Features.Commands.User.Login;

public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, HandlerResult<UserDto>>

{
    protected readonly IUserRepository _userRepository;

    public UserLoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;

    }


    public async Task<HandlerResult<UserDto>> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var userQuery = await _userRepository.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == request.Password);
            if (userQuery!=null) {
                var result = new UserDto()
                {   Id = userQuery.Id,
                    Username = userQuery.Username,
                    Email=userQuery.Email,
                };
                return HandlerResult.Ok(result);
            }
            return HandlerResult.Fail<UserDto>("Username or Password is wrong !");
        }
        catch (Exception ex)
        {
            return HandlerResult.Fail<UserDto>(ex.Message);

        }
    }
}