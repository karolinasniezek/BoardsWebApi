using Boards.Models;
using Microsoft.EntityFrameworkCore;

namespace Boards.Context
{
    public class BoardsDbContext : DbContext
    {
        public BoardsDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public BoardsDbContext(DbContextOptions<BoardsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkItem>(eb =>
            {
                eb.Property(x => x.State).IsRequired();
                eb.Property(x => x.Area).HasColumnType("varchar(200)");
                eb.Property(x => x.IterationPath).HasColumnName("Iteration_path");
                eb.Property(x => x.Efford).HasColumnType("decimal(5,2)");
                eb.Property(x => x.EndDate).HasPrecision(3);
                eb.Property(x => x.Activity).HasMaxLength(200);
                eb.Property(x => x.RemainingWork).HasPrecision(14, 2);
                eb.Property(x => x.Priority).HasDefaultValue(1);
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(x => x.UpdatedDate).ValueGeneratedOnUpdate();
            });

        }
    }
}
