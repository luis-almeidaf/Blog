namespace Blog.Application.Features.Articles.Commands.CreateArticle;

public class CreateArticleResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } 
}