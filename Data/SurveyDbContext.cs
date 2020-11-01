using Microsoft.EntityFrameworkCore;
using Survey.Entities;

namespace Survey.Data
{
    public class SurveyDbContext : DbContext
    {
        public SurveyDbContext (DbContextOptions<SurveyDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Quiz> Quizzes {get;set;}
        public DbSet<Statistical> Statisticals {get;set;}
    }
}