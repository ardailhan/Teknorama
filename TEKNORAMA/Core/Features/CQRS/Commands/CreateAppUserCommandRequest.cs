﻿using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class CreateAppUserCommandRequest : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int AppRoleId { get; set; }
    }
}
