﻿using MediatR;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Features.CQRS.Commands.IssueCommands
{
    public class UpdateIssueCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public DateTime OpenDate { get; set; }
        public string Email { get; set; }
        public int AppUserId { get; set; }
    }
}
