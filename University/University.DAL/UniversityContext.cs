namespace University.DAL
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using University.DAL.Models;

    public class UniversityContext : IdentityDbContext<User, Role, string>
    {
        public UniversityContext() : base()
        { }

        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        { }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=University;Integrated Security=True");
        }
    }
}
