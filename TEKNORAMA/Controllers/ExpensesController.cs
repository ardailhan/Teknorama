using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknoramaBackOffice.Core.Application.Enums;
using TeknoramaBackOffice.Core.Features.CQRS.Commands.ExpenseCommands;
using TeknoramaBackOffice.Core.Features.CQRS.Queries.ExpenseQueries;

namespace TeknoramaBackOffice.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllExpensesQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetExpenseQueryRequest(id));
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id < 1) return NotFound();
            var result = await _mediator.Send(new DeleteExpenseCommandRequest(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("",request);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateExpenseCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok(request);
        }
    }
}
