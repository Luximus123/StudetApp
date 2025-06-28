using System;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstExample
{
    // Student model class
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }

    // DbContext class
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CodeFirstDb;Trusted_Connection=True;");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                context.Database.EnsureCreated();

                var student = new Student { Name = "John Doe" };
                context.Students.Add(student);
                context.SaveChanges();

                Console.WriteLine("Student added successfully!");
            }
        }
    }
}
