using System.Data.Entity;

namespace Lesson11.Models
{
    public class UniversityDbContext : DbContext
    {
        // Your context has been configured to use a 'UniversityDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Lesson11.Models.UniversityDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UniversityDbContext' 
        // connection string in the application configuration file.
        public UniversityDbContext()
            : base("Data Source=HP-PAVILION-550;Initial Catalog=University;Integrated Security=True")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Enrollment>()
            //    .HasRequired(x => x.Student)
            //    .WithMany(s => s.Enrollments)
            //    .HasForeignKey(x => x.StudentId);

            //modelBuilder.Entity<Enrollment>()
            //    .HasRequired(x => x.Subject)
            //    .WithMany(s => s.Enrollments)
            //    .HasForeignKey(x => x.SubjectId);

            base.OnModelCreating(modelBuilder);
        }
    }
}