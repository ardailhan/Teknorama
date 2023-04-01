using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.EmployeeCommands;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeQueries;

namespace TeknoramaBackOffice.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllEmployeesQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetEmployeeQueryRequest(id));
            if(result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id < 1) return NoContent();
            var result = await _mediator.Send(new DeleteEmployeeCommandRequest(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok(request);
        }
    }
}
