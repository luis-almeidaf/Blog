namespace Blog.Application.Features.Articles.Queries.GetArticles;

public class ShortArticleResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public bool IsArchived { get; set; } = false;
    public DateTime CreatedAt { get; set; } 
    
}