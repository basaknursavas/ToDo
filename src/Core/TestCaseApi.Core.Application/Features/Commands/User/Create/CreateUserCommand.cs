using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;

namespace TestCaseApi.Core.Application.Features.Commands.User.Create;

public class CreateUserCommand :IRequest<HandlerResult<int>>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public CreateUserCommand(string userName, string password, string email) 
    {
        Username = userName;
        Password = password;
        Email = email;
    }
}
