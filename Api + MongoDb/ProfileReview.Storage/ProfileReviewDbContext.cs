using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.EntityFrameworkCore.Extensions;
using ProfileReview.Services.Models;

namespace ProfileReview.Storage;

public class ProfileReviewDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; init; }

    public ProfileReviewDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Profile>().ToCollection("testcollection"); 
    }
}
