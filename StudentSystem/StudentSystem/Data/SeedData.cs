using System;
using System.Collections.Generic;
using StudentSystem.Data.Models;

namespace StudentSystem.Data
{
    public static class SeedData
    {
        public static List<Student> GetStudents()
        {
            return new List<Student>
            {
                new Student { StudentId = 1, Name = "Alice Dimitrova", PhoneNumber = "0888123456", RegisteredOn = new DateTime(2025, 1, 15), Birthday = new DateTime(2006, 5, 12) },
                new Student { StudentId = 2, Name = "Boris Petrov", PhoneNumber = "0899123456", RegisteredOn = new DateTime(2025, 2, 1), Birthday = new DateTime(2005, 11, 3) },
                new Student { StudentId = 3, Name = "Chris Ivanov", PhoneNumber = null, RegisteredOn = new DateTime(2025, 2, 10) },
                new Student { StudentId = 4, Name = "Diana Stoyanova", PhoneNumber = "0877123456", RegisteredOn = new DateTime(2025, 3, 5), Birthday = new DateTime(2006, 2, 25) },
                new Student { StudentId = 5, Name = "Emil Georgiev", PhoneNumber = "0887123456", RegisteredOn = new DateTime(2025, 3, 12), Birthday = new DateTime(2005, 7, 19) }
            };
        }

        public static List<Course> GetCourses()
        {
            return new List<Course>
            {
                new Course { CourseId = 1, Name = "C# Fundamentals", Description = "Intro to C#", StartDate = new DateTime(2025, 3, 1), EndDate = new DateTime(2025, 5, 31), Price = 199.00m },
                new Course { CourseId = 2, Name = "Databases 101", Description = "Relational DB basics", StartDate = new DateTime(2025, 3, 15), EndDate = new DateTime(2025, 6, 1), Price = 149.00m },
                new Course { CourseId = 3, Name = "EF Core", Description = "Code First & LINQ", StartDate = new DateTime(2025, 4, 1), EndDate = new DateTime(2025, 6, 15), Price = 179.00m },
                new Course { CourseId = 4, Name = "Web Basics", Description = null, StartDate = new DateTime(2025, 3, 20), EndDate = new DateTime(2025, 5, 20), Price = 99.00m }
            }; 
        }

        public static List<Resource> GetResources()
        {
            return new List<Resource>
            {
                new Resource { ResourceId = 1, Name = "Slides: Intro", Url = "http://example.com/csharp/intro.pdf", ResourceType = ResourceType.Presentation, CourseId = 1 },
                new Resource { ResourceId = 2, Name = "Video: Types", Url = "http://example.com/csharp/types.mp4", ResourceType = ResourceType.Video, CourseId = 1 },
                new Resource { ResourceId = 3, Name = "Doc: Exercises", Url = "http://example.com/csharp/exercises.docx", ResourceType = ResourceType.Document, CourseId = 1 },

                new Resource { ResourceId = 4, Name = "DB Slides", Url = "http://example.com/db/slides.pdf", ResourceType = ResourceType.Presentation, CourseId = 2 },
                new Resource { ResourceId = 5, Name = "Normalization Vid", Url = "http://example.com/db/normalization.mp4", ResourceType = ResourceType.Video, CourseId = 2 },

                new Resource { ResourceId = 6, Name = "EF Docs", Url = "http://example.com/ef/docs.html", ResourceType = ResourceType.Document, CourseId = 3 },
                new Resource { ResourceId = 7, Name = "LINQ Deep Dive", Url = "http://example.com/ef/linq.mp4", ResourceType = ResourceType.Video, CourseId = 3 },

                new Resource { ResourceId = 8, Name = "Web Basics Guide", Url = "http://example.com/web/guide.html", ResourceType = ResourceType.Document, CourseId = 4 },
                new Resource { ResourceId = 9, Name = "CSS Starter", Url = "http://example.com/web/css.pdf", ResourceType = ResourceType.Presentation, CourseId = 4 }
            };
        }

        public static List<Homework> GetHomeworks()
        {
            return new List<Homework>
            {
                new Homework { HomeworkId = 1, Content = "http://hw.local/1.zip", ContentType = ContentType.Zip, SubmissionTime = new DateTime(2025, 3, 10, 18, 30, 0), StudentId = 1, CourseId = 1 },
                new Homework { HomeworkId = 2, Content = "http://hw.local/2.pdf", ContentType = ContentType.Pdf, SubmissionTime = new DateTime(2025, 3, 22, 20, 15, 0), StudentId = 1, CourseId = 2 },
                new Homework { HomeworkId = 3, Content = "http://hw.local/3.app", ContentType = ContentType.Application, SubmissionTime = new DateTime(2025, 4, 5, 19, 0, 0), StudentId = 2, CourseId = 1 },
                new Homework { HomeworkId = 4, Content = "http://hw.local/4.zip", ContentType = ContentType.Zip, SubmissionTime = new DateTime(2025, 4, 18, 21, 0, 0), StudentId = 2, CourseId = 3 },
                new Homework { HomeworkId = 5, Content = "http://hw.local/5.pdf", ContentType = ContentType.Pdf, SubmissionTime = new DateTime(2025, 4, 2, 17, 45, 0), StudentId = 3, CourseId = 2 },
                new Homework { HomeworkId = 6, Content = "http://hw.local/6.zip", ContentType = ContentType.Zip, SubmissionTime = new DateTime(2025, 4, 25, 18, 30, 0), StudentId = 3, CourseId = 4 },
                new Homework { HomeworkId = 7, Content = "http://hw.local/7.app", ContentType = ContentType.Application, SubmissionTime = new DateTime(2025, 5, 1, 20, 0, 0), StudentId = 4, CourseId = 3 },
                new Homework { HomeworkId = 8, Content = "http://hw.local/8.pdf", ContentType = ContentType.Pdf, SubmissionTime = new DateTime(2025, 5, 3, 16, 10, 0), StudentId = 4, CourseId = 1 },
                new Homework { HomeworkId = 9, Content = "http://hw.local/9.zip", ContentType = ContentType.Zip, SubmissionTime = new DateTime(2025, 5, 8, 19, 20, 0), StudentId = 5, CourseId = 2 },
                new Homework { HomeworkId = 10, Content = "http://hw.local/10.app", ContentType = ContentType.Application, SubmissionTime = new DateTime(2025, 5, 28, 22, 15, 0), StudentId = 5, CourseId = 4 }
            };
        }

        public static List<StudentCourse> GetStudentCourses()
        {
            return new List<StudentCourse>
            {
                new StudentCourse { StudentId = 1, CourseId = 1 },
                new StudentCourse { StudentId = 1, CourseId = 2 },
                new StudentCourse { StudentId = 2, CourseId = 1 },
                new StudentCourse { StudentId = 2, CourseId = 3 },
                new StudentCourse { StudentId = 3, CourseId = 2 },
                new StudentCourse { StudentId = 3, CourseId = 4 },
                new StudentCourse { StudentId = 4, CourseId = 1 },
                new StudentCourse { StudentId = 4, CourseId = 3 },
                new StudentCourse { StudentId = 5, CourseId = 2 },
                new StudentCourse { StudentId = 5, CourseId = 4 }
            };
        }
    }
}
