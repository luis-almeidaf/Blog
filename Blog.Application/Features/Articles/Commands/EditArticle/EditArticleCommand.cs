using MediatR;

namespace Blog.Application.Features.Articles.Commands.EditArticle;

public class EditArticleCommand : IRequest<Unit>
{
    public Guid ArticleId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<string> TagNames { get; set; } = [];
}