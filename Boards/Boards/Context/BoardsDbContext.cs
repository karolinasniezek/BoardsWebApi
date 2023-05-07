﻿using Boards.Models;
using Boards.Models.WorkItemTypes;
using Microsoft.EntityFrameworkCore;

namespace Boards.Context
{
    public class BoardsDbContext : DbContext
    {
        public BoardsDbContext(DbContextOptions<BoardsDbContext> options) : base(options)
        {
        }

        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Epic> Epics { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Epic>()
                  .Property(x => x.EndDate).HasPrecision(3);

            modelBuilder.Entity<Issue>()
                 .Property(x => x.Efford).HasColumnType("decimal(5,2)");

            modelBuilder.Entity<TaskItem>()
                 .Property(x => x.Activity).HasMaxLength(200);

            modelBuilder.Entity<TaskItem>()
                 .Property(x => x.RemainingWork).HasPrecision(14, 2);

            modelBuilder.Entity<WorkItem>(eb =>
            {
                eb.Property(x => x.Area).HasColumnType("varchar(200)");
                eb.Property(x => x.IterationPath).HasColumnName("Iteration_path");
                eb.Property(x => x.Priority).HasDefaultValue(1);

                eb.HasMany(w => w.Comments)
                .WithOne(c => c.WorkItem)
                .HasForeignKey(c => c.WorkItemId);

                eb.HasOne(w => w.Author)
                .WithMany(u => u.WorkItems)
                .HasForeignKey(w => w.AuthorId);

                eb.HasMany(w => w.Tags)
                .WithMany(t => t.WorkItems)
                .UsingEntity<WorkItemTag>(
                    w => w.HasOne(wit => wit.Tag) 
                    .WithMany() // tag has many workItemTags
                    .HasForeignKey(wit => wit.TagId),

                     w => w.HasOne(wit => wit.WorkItem)
                    .WithMany() // workItem has many workItemTags
                    .HasForeignKey(wit => wit.WorkItemId),

                     wit =>
                     {
                         wit.HasKey(x => new { x.TagId, x.WorkItemId });
                         wit.Property(x => x.PublicationDate).HasDefaultValueSql("getutcdate()");
                     });

                eb.HasOne(w => w.State)
                .WithMany(s => s.WorkItems)
                .HasForeignKey(w => w.StateId);
            });

            modelBuilder.Entity<Comment>(eb =>
            {
                eb.Property(x => x.CreatedDate).HasDefaultValueSql("getutcdate()");
                eb.Property(x => x.UpdatedDate).ValueGeneratedOnUpdate();
                eb.HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);

            modelBuilder.Entity<State>()
                .Property(sm => sm.Value)
                .IsRequired()
                .HasMaxLength(60);

            modelBuilder.Entity<State>()
                .HasData(new State() {Id = 1, Value = "To Do" }, 
                new State() { Id = 2, Value = "Doing" }, 
                new State() { Id = 3, Value = "Done" });

            modelBuilder.Entity<Tag>()
                .HasData(new Tag() { Id = 1, Value = "Web" },
                new Tag() { Id = 2, Value = "UI" }
                );
        }
    }
}
