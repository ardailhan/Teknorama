using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Domain
{
    public class Issue
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; } = IssueStatus.Open;
        public DateTime OpenDate { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public int? AppUserId { get; set; }

        //Navigation Properties
        public virtual AppUser AppUser { get; set; }
    }
}
