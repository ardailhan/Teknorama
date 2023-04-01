using System.ComponentModel.DataAnnotations;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaUI.Models.IssueModel
{
    public class IssueUpdateRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject must not be empty")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Answer must not be empty")]
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; } = IssueStatus.Open;
        public DateTime OpenDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Email must not be empty")]
        public string Email { get; set; }
        public int? AppUserId { get; set; }
    }
}
