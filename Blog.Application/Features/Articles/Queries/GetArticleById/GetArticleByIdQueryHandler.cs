using Blog.Domain.Entities;
using Blog.Domain.Repositories.Article;
using MediatR;

namespace Blog.Application.Features.Articles.Queries.GetArticleById;

public class GetArticleByIdQueryHandler(IArticleReadOnlyRepository repository)
    : IRequestHandler<GetArticleByIdQuery, GetArticleByIdQueryResponse>
{
    public async Task<GetArticleByIdQueryResponse> Handle(GetArticleByIdQuery request,
        CancellationToken cancellationToken)
    {
        var article = await repository.GetArticleById(request.Id);

        var response = new GetArticleByIdQueryResponse
        {
            Id = article.Id,
            Title = article.Title,
            Content = article.Content,
            CreatedAt = article.CreatedAt,
            UpdatedAt = article.UpdatedAt,
            Tags = new List<Tag>()
        };

        foreach (var tag in article.Tags)
        {
            response.Tags.Add(tag);
        }
        
        return response;
    }
}