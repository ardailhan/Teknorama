using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Domain
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime MessageDate { get; set; } = DateTime.Now;
        public MessageType MessageType { get; set; }
    }
}
