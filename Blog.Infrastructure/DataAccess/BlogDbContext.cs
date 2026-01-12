using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DataAccess;

public class BlogDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Article> Articles { get; set; }
    public DbSet<User> Users { get; set; }
}