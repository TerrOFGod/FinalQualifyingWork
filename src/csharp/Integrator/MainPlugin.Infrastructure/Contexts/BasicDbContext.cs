using MainPlugin.Core.Entities.Models.Interactions;
using Microsoft.EntityFrameworkCore;
using MainPlugin.Core.Entities.Interfaces;

namespace MainPlugin.Infrastructure.Contexts
{
    public class BasicDbContext : DbContext
    {
        public DbSet<DialogueEntry> DialogueEntries { get; set; }
        public DbSet<DialogueNode> DialogueNodes { get; set; }

        public BasicDbContext(DbContextOptions<BasicDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DialogueEntry>(entity =>
            {
                entity.HasKey(x => x.ID);
                entity.HasMany(x => x.Childs)
                      .WithOne()
                      .HasForeignKey(x => x.ID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DialogueNode>(entity =>
            {
                entity.HasKey(x => x.ID);
                entity.HasMany(x => x.Childs)
                      .WithOne()
                      .HasForeignKey(x => x.ID)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
