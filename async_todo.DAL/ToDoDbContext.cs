using Microsoft.EntityFrameworkCore;
using async_todo.DAL.Entities;
namespace async_todo.DAL
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
