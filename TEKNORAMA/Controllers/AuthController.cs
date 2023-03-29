using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeknoramaBackOffice.Core.DTOs;
using TeknoramaBackOffice.Core.Features.CQRS.Commands;
using TeknoramaBackOffice.Core.Features.CQRS.Queries;
using TeknoramaBackOffice.Infrastructure.Tools;

namespace TeknoramaBackOffice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //api/Auth/Register
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("", request);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {
            CheckUserResponseDto userDto = await _mediator.Send(request);
            if (userDto != null && userDto.Active) 
            {
                var token = JwtGenerator.GenerateToken(userDto);

                return Created("",token);
            }

            return BadRequest("Username or password is invalid");
        }
    }
}
