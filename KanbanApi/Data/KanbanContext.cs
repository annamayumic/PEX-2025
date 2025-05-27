using Microsoft.EntityFrameworkCore;
using KanbanApi.Models;

namespace KanbanApi.Data
{
    public class KanbanContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18,2)"); 
        }
        public KanbanContext(DbContextOptions<KanbanContext> options) : base(options) { }

        public DbSet<TaskModel> Tasks { get; set; }
        


    }
}
