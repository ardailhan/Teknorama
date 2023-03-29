﻿using MediatR;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands
{
    public class DeleteIssueCommandRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteIssueCommandRequest(int id)
        {
            Id = id;
        }
    }
}
