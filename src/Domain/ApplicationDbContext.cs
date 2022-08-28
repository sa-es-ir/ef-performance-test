﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasIndex(x => x.Title);

    }

    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Author> Authors { get; set; }
}