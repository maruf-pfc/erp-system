using ERP.Application.Features.HR.Commands.CreateEmployee;
using ERP.Application.Features.HR.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null)
    {
        var result = await _mediator.Send(
            new GetEmployeesQuery(pageNumber, pageSize, search));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return result.Succeeded
            ? CreatedAtAction(nameof(GetAll), new { id = result.Data }, result)
            : BadRequest(result);
    }
}