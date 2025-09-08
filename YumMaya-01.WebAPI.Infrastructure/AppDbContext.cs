using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RecipeTag>()
            .HasKey(rt => new {rt.RecipeId, rt.TagId });

        builder.Entity<RecipeTag>()
            .HasOne(rt => rt.Recipe)
            .WithMany(r => r.RecipeTags)
            .HasForeignKey(rt => rt.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RecipeTag>()
            .HasOne(rt => rt.Tag)
            .WithMany(t => t.RecipeTags)
            .HasForeignKey(rt => rt.TagId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Recipe>()
            .HasKey(r => r.Id);

        builder.Entity<Recipe>()
            .Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Entity<Recipe>()
            .Property(r => r.Description)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.Entity<Recipe>()
            .Property(r => r.Instructions)
            .IsRequired(false)
            .HasMaxLength(100000);

        builder.Entity<Recipe>()
            .Property(r => r.Ingredients)
            .IsRequired(false)
            .HasMaxLength(10000);

        builder.Entity<Tag>()
            .HasKey(t => t.Id);

        builder.Entity<Tag>()
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<User>()
            .HasKey(u => u.Id);

        builder.Entity<User>()
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Entity<User>()
            .Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(60);

        builder.Entity<RecipeTag>()
            .HasIndex(rt => rt.TagId );

        builder.Entity<RecipeTag>()
            .HasIndex(rt => rt.RecipeId);

        base.OnModelCreating(builder);
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTags { get; set; }
    public DbSet<User> Users { get; set; }
}