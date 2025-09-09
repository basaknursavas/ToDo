using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestCaseApi.Core.Application.Features.Commands.Todo.Create;
using TestCaseApi.Core.Application.Features.Commands.Todo.Update;
using TestCaseApi.Core.Application.Features.Queries.Todo.Delete;
using TestCaseApi.Core.Application.Features.Queries.Todo.GetAll;
using TestCaseApi.Core.Application.Features.Queries.Todo.GetById;

namespace TestCaseApi.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ToDoController: ControllerBase
{
    protected readonly IMediator _mediator;

    public ToDoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllToDos()
    {
        var result = await _mediator.Send(new GetAllTodosQuery());
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetTodoById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new GetTodoByIdQuery(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateTodo([FromBody] CreateTodoCommand command)
    {
        var result = await _mediator.Send(command);
        if(result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult> UpdateTodo([FromBody] UpdateTodoCommand command){
        var result = await _mediator.Send(command);
        if(result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> DeleteTodoById([FromRoute] Guid id)
    {
        var result = await _mediator.Send(new DeleteTodoByIdQuery(id));
        return Ok(result);
    }


}
