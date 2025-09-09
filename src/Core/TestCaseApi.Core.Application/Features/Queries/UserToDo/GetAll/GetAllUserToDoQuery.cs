using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;

namespace TestCaseApi.Core.Application.Features.Queries.UserToDo.GetAll;

public class GetAllUserToDoQuery:IRequest<HandlerResult<List<Domain.Models.UserToDo>>>
{
}
