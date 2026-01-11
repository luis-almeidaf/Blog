using MediatR;

namespace Blog.Application.Features.Articles.Commands.CreateArticle;

public class CreateArticleCommand : IRequest<CreateArticleResponse>
{
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<string> TagNames { get; set; } = [];
}