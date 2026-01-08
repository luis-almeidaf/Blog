using Blog.Domain.Repositories.Article;
using MediatR;

namespace Blog.Application.Features.Articles.Queries.GetArticles;

public class GetArticlesQueryHandler(IArticleReadOnlyRepository repository)
    : IRequestHandler<GetArticlesQuery, GetArticlesQueryResponse>
{
    public async Task<GetArticlesQueryResponse> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await repository.GetArticles();

        var response = new GetArticlesQueryResponse();
        foreach (var article in articles)
        {
            response.Articles.Add(new ShortArticleResponse
            {
                Id = article.Id,
                Title = article.Title,
                CreatedAt = article.CreatedAt,
                IsArchived =  article.IsArchived,
            });
        }
        
        return response;
    }
}