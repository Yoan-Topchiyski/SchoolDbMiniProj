using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configuration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.ResourceId);

            builder.Property(r => r.ResourceId)
                   .ValueGeneratedNever();

            builder.Property(r => r.Name)
                   .HasMaxLength(50)
                   .IsUnicode(true)
                   .IsRequired();

            builder.Property(r => r.Url)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(r => r.ResourceType)
                   .IsRequired();
        }
    }
}
