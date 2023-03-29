﻿using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class UpdateAppRoleCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
