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
    }
}
