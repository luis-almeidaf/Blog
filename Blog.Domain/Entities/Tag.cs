namespace Blog.Domain.Entities;

public class Tag
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long ArticleId { get; set; }
    public Article Article { get; set; } = null!;
}