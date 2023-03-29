﻿using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteEmployeeCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteEmployeeCommandRequest(int id)
        {
            Id = id;
        }
    }
}
