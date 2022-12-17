using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScreeningTool.Models;

namespace ScreeningTool.Data
{
    public class ApplicationDbContext : IdentityDbContext<ScreeningUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ScreeningUser> ScreeningUsers { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
