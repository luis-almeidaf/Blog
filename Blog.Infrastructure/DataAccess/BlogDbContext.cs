using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DataAccess;

public class BlogDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tag>().ToTable("Tags");
    }
}