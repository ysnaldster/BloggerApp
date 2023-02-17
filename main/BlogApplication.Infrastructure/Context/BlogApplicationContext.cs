using BlogApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Infrastructure.Context;

public class BlogApplicationContext : DbContext
{
    public BlogApplicationContext(DbContextOptions<BlogApplicationContext> options) : base(options)
    {
    }
    
    // Config Fluent API
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Label> Labels { get; set; }
    public DbSet<PostLabelPivot> PostLabelPivots { get; set; }

    // Create Schemas with Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Create UserSchema
        modelBuilder.Entity<User>(user =>
        {
            user.ToTable("User");
            user.HasKey(p => p.Id);
            user.Property(p => p.Name).IsRequired().HasMaxLength(50).HasColumnName("Name");
            user.Property(p => p.Password).IsRequired().HasColumnName("Password");
            user.Property(p => p.Nickname).IsRequired(false).HasColumnName("Nickname");
            user.Property(p => p.Email).IsRequired().HasColumnName("Email");
            user.Property(p => p.CreationDate).HasColumnName("Creation_date").HasDefaultValue(DateTime.Now);
            user.Property(p => p.UpdateDate).HasColumnName("Update_date").HasDefaultValue(DateTime.Now);

            user.HasData(InitData.LoadUsers());
        });

        // Create PostSchema
        
        modelBuilder.Entity<Post>(post =>
        {
            post.ToTable("post");
            post.HasKey(p => p.Id);
            post.HasOne(p => p.User).WithMany(p => p.Posts);
            post.HasOne(p => p.Category).WithMany(p => p.Posts);
            post.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
            post.Property(p => p.PublicationDate).HasColumnName("Publication_date").HasDefaultValue(DateTime.Now);
            post.Property(p => p.Content).HasColumnName("Content").HasMaxLength(200);
            post.Property(p => p.Author).HasColumnName("Author").HasMaxLength(50);
            post.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(null);

            post.HasData(InitData.LoadPosts());
        });
        
        // Create CommentSchema
        modelBuilder.Entity<Comment>(comment =>
        {
            comment.ToTable("Comment");
            comment.HasKey(p => p.Id);
            comment.HasOne(p => p.Post).WithMany(p => p.Comments).OnDelete(DeleteBehavior.Cascade);
            comment.HasOne(p => p.User).WithMany(p => p.Comments).OnDelete(DeleteBehavior.Cascade);
            comment.Property(p => p.Content).HasMaxLength(200).HasColumnName("Content").IsRequired(false);
            comment.Property(p => p.PublicationDate).HasDefaultValue(DateTime.Now).HasColumnName("Publication_date");
            comment.HasData(InitData.LoadComments());
        });

        // Create CategorySchema
        
        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.Id);
            category.Property(p => p.Name).HasColumnName("Name");
            category.HasData(InitData.LoadCategories());
        });
        
        // Create LabelSchema
        modelBuilder.Entity<Label>(label =>
        {
            label.ToTable("Label");
            label.HasKey(p => p.Id);
            label.Property(p => p.Name).HasColumnName("Name");

            label.HasData(InitData.LoadLabels());
        });

        //Create Pivot Table Post_Label
        modelBuilder.Entity<PostLabelPivot>(pivot =>
        {
            pivot.ToTable("Post_label");
            pivot.HasKey(p => p.Id);
            pivot.HasOne(p => p.Label).WithMany(p => p.LabelPivots);
            pivot.HasOne(p => p.Post).WithMany(p => p.PostPivots);

            pivot.HasData(InitData.LoadPostLabelPivot());
        });
    }
}