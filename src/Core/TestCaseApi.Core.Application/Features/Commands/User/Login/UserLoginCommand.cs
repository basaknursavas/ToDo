using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Dtos;

namespace TestCaseApi.Core.Application.Features.Commands.User.Login;

public class UserLoginCommand:IRequest<HandlerResult<UserDto>>
{
    public required string Username { get; set; }
    public required string Password { get; set; }

}
