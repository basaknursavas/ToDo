using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Domain.Models;

namespace TestCaseApi.Core.Application.Features.Queries.Todo.GetAll;

public class GetAllTodosQuery:IRequest<HandlerResult<List<ToDo>>>
{

}
