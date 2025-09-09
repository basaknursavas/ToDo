using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;

namespace TestCaseApi.Core.Application.Features.Queries.User.GetAll
{
    public class GetAllUserQuery:IRequest<HandlerResult<List<Domain.Models.User>>>
    {
    }
}
