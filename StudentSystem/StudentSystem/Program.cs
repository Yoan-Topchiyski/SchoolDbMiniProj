using Microsoft.EntityFrameworkCore;
using StudentSystem.Data;
using StudentSystem.Data.Models;

namespace StudentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new StudentSystemContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Students.Any())
            {
                context.Students.AddRange(SeedData.GetStudents());
                context.Courses.AddRange(SeedData.GetCourses());
                context.SaveChanges();

                context.Resources.AddRange(SeedData.GetResources());
                context.Homeworks.AddRange(SeedData.GetHomeworks());
                context.StudentCourses.AddRange(SeedData.GetStudentCourses());
                context.SaveChanges();
            }

            var students = context.Students.ToList();
            var courses = context.Courses.ToList();
            var resources = context.Resources.ToList();
            var homeworks = context.Homeworks.ToList();
            var enrollments = context.StudentCourses.ToList();

            

            Console.WriteLine("=== LINQ Query 1: List all students with their registered date and number of courses ===");
            var studentsWithCourses = context.Students
                .Select(s => new
                {
                    s.Name,
                    s.RegisteredOn,
                    CourseCount = s.CourseEnrollments.Count
                })
                .ToList();

            foreach (var student in studentsWithCourses)
            {
                Console.WriteLine($"Student: {student.Name}, Registered: {student.RegisteredOn:yyyy-MM-dd}, Courses: {student.CourseCount}");
            }
            Console.WriteLine();

            Console.WriteLine("=== LINQ Query 2: List all courses with total number of resources ===");
            var coursesWithResources = context.Courses
                .Select(c => new
                {
                    c.Name,
                    ResourceCount = c.Resources.Count
                })
                .ToList();

            foreach (var course in coursesWithResources)
            {
                Console.WriteLine($"Course: {course.Name}, Resources: {course.ResourceCount}");
            }
            Console.WriteLine();

            Console.WriteLine("=== LINQ Query 3: Show all homework submissions for a given student ===");
            int studentId = 1;
            var studentHomeworks = context.Homeworks
                .Where(h => h.StudentId == studentId)
                .Select(h => new
                {
                    h.Content,
                    h.ContentType,
                    h.SubmissionTime,
                    CourseName = h.Course.Name
                })
                .ToList();

            var studentName = context.Students.FirstOrDefault(s => s.StudentId == studentId)?.Name ?? "Unknown";
            Console.WriteLine($"Homework submissions for student: {studentName} (ID: {studentId})");
            foreach (var hw in studentHomeworks)
            {
                Console.WriteLine($"  Course: {hw.CourseName}, Content: {hw.Content}, Type: {hw.ContentType}, Submitted: {hw.SubmissionTime:yyyy-MM-dd HH:mm}");
            }
            Console.WriteLine();

            Console.WriteLine("=== LINQ Query 4: Show students ordered by number of courses they are enrolled in ===");
            var studentsOrderedByCourses = context.Students
                .Select(s => new
                {
                    s.Name,
                    CourseCount = s.CourseEnrollments.Count
                })
                .OrderByDescending(s => s.CourseCount)
                .ToList();

            foreach (var student in studentsOrderedByCourses)
            {
                Console.WriteLine($"Student: {student.Name}, Courses: {student.CourseCount}");
            }
            Console.WriteLine();

            Console.WriteLine("=== LINQ Query 5: Show all courses that have at least one homework submitted after their end date ===");
            var coursesWithLateHomework = context.Courses
                .Where(c => c.HomeworkSubmissions.Any(h => h.SubmissionTime > c.EndDate))
                .Select(c => new
                {
                    c.Name,
                    c.EndDate,
                    LateSubmissions = c.HomeworkSubmissions
                        .Where(h => h.SubmissionTime > c.EndDate)
                        .Select(h => new
                        {
                            h.Content,
                            h.SubmissionTime,
                            StudentName = h.Student.Name
                        })
                        .ToList()
                })
                .ToList();

            foreach (var course in coursesWithLateHomework)
            {
                Console.WriteLine($"Course: {course.Name}, End Date: {course.EndDate:yyyy-MM-dd}");
                foreach (var lateHw in course.LateSubmissions)
                {
                    Console.WriteLine($"  Late submission by {lateHw.StudentName}: {lateHw.Content}, Submitted: {lateHw.SubmissionTime:yyyy-MM-dd HH:mm}");
                }
            }
        }
    }
}
