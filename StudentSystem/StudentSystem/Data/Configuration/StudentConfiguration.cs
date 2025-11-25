using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentSystem.Data.Models;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.StudentId);

        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(true);

        builder.Property(s => s.PhoneNumber)
               .HasMaxLength(10)
               .IsUnicode(false)
               .IsFixedLength(true);

        builder.Property(s => s.RegisteredOn)
               .IsRequired();

        builder.Property(s => s.Birthday)
               .IsRequired(false);

        builder.HasMany(s => s.HomeworkSubmissions)
               .WithOne(h => h.Student)
               .HasForeignKey(h => h.StudentId);

    }
}
