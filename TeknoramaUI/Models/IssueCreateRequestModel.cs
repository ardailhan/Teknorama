using System.ComponentModel.DataAnnotations;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaUI.Models
{
    public class IssueCreateRequestModel
    {
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
