using MediatR;

namespace Blog.Application.Features.Articles.Commands.UnarchiveArticle;

public class UnarchiveArticleCommand : IRequest<Unit>
{
    public Guid ArticleId { get; init; }
}