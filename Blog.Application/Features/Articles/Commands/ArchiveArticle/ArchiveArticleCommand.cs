using MediatR;

namespace Blog.Application.Features.Articles.Commands.ArchiveArticle;

public class ArchiveArticleCommand : IRequest<Unit>
{
    public Guid ArticleId { get; init; }
}