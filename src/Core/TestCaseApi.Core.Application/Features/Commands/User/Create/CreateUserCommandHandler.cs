using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseApi.Common.SharedKernel.ReturnTypes;
using TestCaseApi.Core.Application.Interfaces;

namespace TestCaseApi.Core.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand, HandlerResult<int>>
    {

        //The data will send to database with repository. 

        protected readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<HandlerResult<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken) //with request object we can fetch the User datas.
        {

            try
            {
                var result = await _userRepository.AddAsync(new Domain.Models.User() //we create domain entity.
                                                                                    // here we create a new user object.                                                                                     // we can add the new object to database with repository 
                {
                    Username = request.Username, 
                    Password = request.Password, 
                    Email = request.Email,
                });

                return HandlerResult.Ok(result);
            }
            catch (Exception ex)
            {
                return HandlerResult.Fail<int>(ex.Message);
            }
        }
    }
}
