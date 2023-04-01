using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.AppUserCommands;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.AppUserQueries;

namespace TeknoramaBackOffice.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _mediator.Send(new GetAllAppUsersQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return NotFound();
            var result = await _mediator.Send(new GetAppUserQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return NotFound();
            var result = await _mediator.Send(new DeleteAppUserCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("",request);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
