using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoramaBackOffice.Core.Domain;

namespace TeknoramaBackOffice.Persistance.Configurations.MessageConfigurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Subject).HasMaxLength(100);
            builder.Property(m => m.Description).HasMaxLength(500);
            builder.Property(m => m.Email).HasMaxLength(100);
            builder.Property(m => m.MessageType).HasConversion<string>();
        }
    }
}
