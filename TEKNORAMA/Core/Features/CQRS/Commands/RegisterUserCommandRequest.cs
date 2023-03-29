﻿using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class RegisterUserCommandRequest : IRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
