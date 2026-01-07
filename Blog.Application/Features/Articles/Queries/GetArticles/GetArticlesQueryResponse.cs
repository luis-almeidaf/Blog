using System.Collections;
using Blog.Domain.Entities;

namespace Blog.Application.Features.Articles.Queries.GetArticles;

public class GetArticlesQueryResponse
{
    public List<ShortArticleResponse> Articles { get; set; } = [];
}