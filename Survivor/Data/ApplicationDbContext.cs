﻿using Microsoft.EntityFrameworkCore;
using Survivor.Data.Entities;

namespace Survivor.Data
{
    public class ApplicationDbContext:DbContext
    {

        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Competitors> Competitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competitors>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.CategoryId).IsRequired();
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasMany(e => e.Competitors)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);
            });





        }

    }
}
