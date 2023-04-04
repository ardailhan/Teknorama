using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.AppRoleCommands;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.AppRoleQueries;

namespace TeknoramaBackOffice.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AppRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _mediator.Send(new GetAllAppRolesQueryRequest()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if(id < 1) return NotFound();
            var result = await _mediator.Send(new GetAppRoleQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id < 0) return NotFound();
            var result = await _mediator.Send(new DeleteAppRoleCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppRoleCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppRoleCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
