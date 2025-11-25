using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using StudentSystem.Data.Models;

namespace StudentSystem.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.CourseId)
                   .ValueGeneratedNever();

            builder.Property(c => c.Name)
                   .HasMaxLength(80)
                   .IsUnicode(true)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .IsUnicode(true)
                   .IsRequired(false);

            builder.Property(c => c.StartDate)
                   .IsRequired();

            builder.Property(c => c.EndDate)
                   .IsRequired();

            builder.Property(c => c.Price)
                   .HasColumnType("decimal(18,2)");

            builder.HasMany(c => c.HomeworkSubmissions)
                   .WithOne(h => h.Course)
                   .HasForeignKey(h => h.CourseId);

            builder.HasMany(c => c.Resources)
                   .WithOne(r => r.Course)
                   .HasForeignKey(r => r.CourseId);
        }
    }
}
