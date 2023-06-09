﻿using TeknoramaBackOffice.Core.Application.Enums;
using TeknoramaUI.Areas.Administration.Models.AppuserModel;

namespace TeknoramaUI.Areas.Administration.Models.IssueModel
{
    public class IssueListResponseModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; } = IssueStatus.Open;
        public DateTime OpenDate { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public int? AppUserId { get; set; }
        public AppUserListResponseModel AppUser { get; internal set; }
    }
}
