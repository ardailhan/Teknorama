using TeknoramaBackOffice.Core.Application.Enums;

namespace TeknoramaBackOffice.Core.Domain
{
    public abstract class BaseEntity
    {
        public DataStatus Status { get; set; }
    }
}
