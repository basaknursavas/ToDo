
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TestCaseApi.Core.Application.Features.Queries.User.GetAll;
using TestCaseApi.Core.Application.Features.Commands.User.Create;
using TestCaseApi.Core.Application.Features.Commands.User.Update;
using TestCaseApi.Core.Application.Features.Queries.UserToDo.GetAll;
using TestCaseApi.Core.Application.Features.Queries.User.GetUserToDos;
using TestCaseApi.Core.Application.Features.Commands.User.Login;


namespace TestCaseApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        protected readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        
        public async Task<ActionResult> GetUserById([FromRoute] Guid id )
        {
            var result = await _mediator.Send(GetUserById(id));
            return Ok(result);
        }

        [HttpPost] 
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}/todo")]
        public async Task<IActionResult> GetUserTodos([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetUserToDosQuery(id));
            if(result.IsSuccess)
                return Ok(result);

            return BadRequest();
        }


        [HttpPost]
        [Route("login")]

        public async Task<ActionResult> UserLogin([FromBody] UserLoginCommand command)
        {
            var result= await _mediator.Send(command);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest();
        }


    }
}
