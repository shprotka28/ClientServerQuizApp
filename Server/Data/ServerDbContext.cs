using Microsoft.EntityFrameworkCore;
using Server.Models;
namespace Server.Data
{
    public class ServerDbContext : DbContext
    {
        public ServerDbContext(DbContextOptions<ServerDbContext> options)
            : base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Quiz>  Quizzes { get; set; }
        
        public DbSet<Category> Category { get; set; }

        public DbSet<Rank> Rank { get; set; }

    }
}
