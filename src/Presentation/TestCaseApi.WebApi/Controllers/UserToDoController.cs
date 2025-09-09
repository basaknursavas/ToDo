using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestCaseApi.Core.Application.Features.Commands.UserToDo.Insert;
using TestCaseApi.Core.Application.Features.Queries.UserToDo.GetAll;


namespace TestCaseApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserToDoController : ControllerBase
{

    protected readonly IMediator _mediator;

    public UserToDoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllUserToDo()
    {
        var result = await _mediator.Send(new GetAllUserToDoQuery());
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]

    public async Task<ActionResult> GetUserToDoById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(GetUserToDoById(id));
        return Ok(result);
    }


    [HttpPost]
    public async Task<ActionResult> InsertUserToDo([FromBody] InsertUserToDoCommand command)
    {
        var result = await _mediator.Send(command);
        if(result.IsSuccess) 
            return Ok(result);
        return BadRequest(result);

    }
}
