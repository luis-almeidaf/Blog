namespace Blog.Domain.Entities;

public class Article
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsPublished { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public ICollection<Tag> Tags { get; set; } = [];
}