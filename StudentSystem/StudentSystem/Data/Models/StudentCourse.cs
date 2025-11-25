namespace StudentSystem.Data.Models
{
    // Junction table entity for many-to-many relationship between Student and Course
    // Composite primary key with StudentId and CourseId, navigation properties to both entities
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

