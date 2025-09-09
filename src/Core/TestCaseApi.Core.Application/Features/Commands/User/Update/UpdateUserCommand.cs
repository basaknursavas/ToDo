
using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;

namespace TestCaseApi.Core.Application.Features.Commands.User.Update;

public class UpdateUserCommand:IRequest<HandlerResult<int>>
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}
