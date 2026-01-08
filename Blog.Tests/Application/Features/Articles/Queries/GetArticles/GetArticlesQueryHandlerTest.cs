using Blog.Application.Features.Articles.Queries.GetArticles;
using Blog.Domain.Entities;
using Blog.Tests.Builders.Repositories;

namespace Blog.Tests.Application.Features.Articles.Queries.GetArticles;

public class GetArticlesQueryHandlerTest
{
    [Fact]
    public async Task ShouldReturnAllArticles()
    {
        var article = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Test Title",
            Content = "Test Content",
        };
        var handler = CreateHandler(article);
        var result = await handler.Handle(new GetArticlesQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Single(result.Articles);
        Assert.Equal(article.Id, result.Articles[0].Id);
        Assert.Equal(article.Title, result.Articles[0].Title);
        Assert.Equal(article.CreatedAt, result.Articles[0].CreatedAt);
    }

    [Fact]
    public async Task ShouldReturnEmptyArticleList()
    {
        var handler = CreateHandler();
        var result = await handler.Handle(new GetArticlesQuery(), CancellationToken.None);

        Assert.NotNull(result);
        Assert.Empty(result.Articles);
    }

    private static GetArticlesQueryHandler CreateHandler(Article? article = null)
    {
        var articleReadOnlyRepository = new ArticleReadOnlyRepositoryBuilder();
        if (article is null)
            articleReadOnlyRepository.GetArticles();
        else
            articleReadOnlyRepository.GetArticles(article);

        return new GetArticlesQueryHandler(articleReadOnlyRepository.Build());
    }
}