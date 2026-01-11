namespace Blog.Application.Features.Articles.Commands.EditArticle;

public class EditArticleViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<string> TagNames { get; set; } = [];
}