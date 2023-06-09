﻿using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.DTOs
{
    public class IssueListDto
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public DateTime OpenDate { get; set; }
        public string Email { get; set; }
    }
}
