using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;

namespace TeknoramaBackOffice.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize("Admin")]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllSuppliersQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetSupplierQueryRequest(id));
            if(result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(id < 1) return NotFound();
            var result = await _mediator.Send(new DeleteSupplierCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSupplierCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("",request);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSupplierCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok(request);
        }
    }
}
