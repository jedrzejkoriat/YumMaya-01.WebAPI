using Microsoft.EntityFrameworkCore;
using YumMaya_01.WebAPI.Domain.Models;
using YumMaya_01.WebAPI.Infrastructure.Persistence.Entities;

namespace YumMaya_01.WebAPI.Infrastructure.Persistence;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Category entity configuration
        builder.Entity<Category>()
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.ApplyConfiguration(new CategorySeedConfiguration());

        // Comment entity configuration
        builder.Entity<Comment>()
            .HasOne(c => c.Recipe)
            .WithMany(r => r.Comments)
            .HasForeignKey(c => c.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Comment>()
            .Property(c => c.CommenterName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Entity<Comment>()
            .Property(c => c.Content)
            .IsRequired()
            .HasMaxLength(500);

        builder.Entity<Comment>()
            .Property(c => c.IpAddress)
            .IsRequired()
            .HasMaxLength(45);

        // CommentReply entity configuration
        builder.Entity<CommentReply>()
            .HasOne(cr => cr.Comment)
            .WithMany(c => c.CommentReplies)
            .HasForeignKey(cr => cr.CommentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CommentReply>()
            .Property(cr => cr.CommenterName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Entity<CommentReply>()
            .Property(cr => cr.Content)
            .IsRequired()
            .HasMaxLength(500);

        builder.Entity<CommentReply>()
            .Property(cr => cr.IpAddress)
            .IsRequired()
            .HasMaxLength(45);

        // Newsletter entity configuration
        builder.Entity<NewsletterSubscriber>()
            .Property(ns => ns.Email)
            .IsRequired()
            .HasMaxLength(150);

        // Notification entity configuration
        builder.Entity<Notification>()
            .Property(n => n.Message)
            .IsRequired()
            .HasMaxLength(500);

        builder.Entity<Notification>()
            .Property(n => n.IsRead)
            .HasDefaultValue(false);

        builder.Entity<Notification>()
            .HasOne(n => n.Recipe)
            .WithMany()
            .HasForeignKey(n => n.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Recipe entity configuration
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

        builder.Entity<Recipe>()
            .Property(r => r.PreparationTime)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Entity<Recipe>()
            .Property(r => r.CookingTime)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Entity<Recipe>()
            .Property(r => r.Servings)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Entity<Recipe>()
            .Property(r => r.IsArchived)
            .IsRequired()
            .HasDefaultValue(true);

        // RecipeCategory entity configuration
        builder.Entity<RecipeCategory>()
            .HasKey(rt => new { rt.RecipeId, rt.CategoryId });

        builder.Entity<RecipeCategory>()
            .HasOne(rt => rt.Recipe)
            .WithMany(r => r.RecipeCategories)
            .HasForeignKey(rt => rt.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RecipeCategory>()
            .HasOne(rt => rt.Category)
            .WithMany(t => t.RecipeCategories)
            .HasForeignKey(rt => rt.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        // RecipeLike entity configuration
        builder.Entity<RecipeLike>()
            .HasOne(rl => rl.Recipe)
            .WithMany()
            .HasForeignKey(rl => rl.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RecipeLike>()
            .Property(rl => rl.IpAddress)
            .IsRequired()
            .HasMaxLength(45);

        // RecipeTag entity configuration
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

        // Tag entity configuration
        builder.Entity<Tag>()
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.ApplyConfiguration(new TagSeedConfiguration());

        // User entity configuration
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

        base.OnModelCreating(builder);
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentReply> CommentReplies { get; set; }
    public DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeCategory> RecipeCategories { get; set; }
    public DbSet<RecipeLike> RecipeLikes { get; set; }
    public DbSet<RecipeTag> RecipeTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<User> Users { get; set; }
}