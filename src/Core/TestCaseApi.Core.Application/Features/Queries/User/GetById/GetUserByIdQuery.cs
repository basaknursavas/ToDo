using MediatR;
using TestCaseApi.Common.SharedKernel.ReturnTypes;


namespace TestCaseApi.Core.Application.Features.Queries.User.GetById
{
    public class GetUserByIdQuery:IRequest<HandlerResult<Domain.Models.User>>
    {
        public Guid Id { get; set; }

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
