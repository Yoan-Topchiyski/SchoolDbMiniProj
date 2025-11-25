using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Data.Models;

public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
{
    public void Configure(EntityTypeBuilder<Homework> builder)
    {
        builder.HasKey(h => h.HomeworkId);

        builder.Property(h => h.Content)
               .IsUnicode(false)
               .IsRequired();

        builder.Property(h => h.ContentType)
               .IsRequired();

        builder.Property(h => h.SubmissionTime)
               .IsRequired();
    }
}
