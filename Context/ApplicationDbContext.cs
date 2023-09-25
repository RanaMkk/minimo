using Microsoft.EntityFrameworkCore;
using minimo.Models;

namespace minimo.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        //RegisterModels
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
    }


}
