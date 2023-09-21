using Microsoft.EntityFrameworkCore;

namespace OnlyTutorsBackEnd.Models
{
    public class DataContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectPricing> SubjectPricings { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<User> Users { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseSqlServer(@""); }
    }
}