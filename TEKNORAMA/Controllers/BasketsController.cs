using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.BasketCommands;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.BasketQueries;

namespace TeknoramaBackOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllBasketsQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1) return NotFound();
            var result = await _mediator.Send(new GetBasketQueryRequest(id));
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return NotFound();
            var result = await _mediator.Send(new DeleteBasketCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBasketCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBasketCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
