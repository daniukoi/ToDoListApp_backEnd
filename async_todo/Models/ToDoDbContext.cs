using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace async_todo.Models
{
    public partial class ToDoDbContext : DbContext
    {
        public ToDoDbContext()
        {
        }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ALEXDANYUK3C35\\ALEXDANYUKSERVER;Database=ToDoDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Task)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
