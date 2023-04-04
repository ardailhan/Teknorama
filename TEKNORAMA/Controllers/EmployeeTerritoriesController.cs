using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.EmployeeTerritoryCommands;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.EmployeeTerritoryQueries;

namespace TeknoramaBackOffice.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EmployeeTerritoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeTerritoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllEmployeeTerritoriesQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetEmployeeTerritoryQueryRequest(id));
            if(result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeTerritoryCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
    }
}
