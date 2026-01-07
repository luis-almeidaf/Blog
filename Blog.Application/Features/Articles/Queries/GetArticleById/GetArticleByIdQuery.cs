using Blog.Application.Features.Articles.Queries.GetArticles;
using MediatR;

namespace Blog.Application.Features.Articles.Queries.GetArticleById;

public class GetArticleByIdQuery : IRequest<GetArticleByIdQueryResponse>
{
    public Guid Id { get; set; }
}