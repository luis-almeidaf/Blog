using Blog.Application.Features.Articles.Queries.GetArticleById;
using Blog.Domain.Entities;
using Blog.Tests.Builders.Repositories;

namespace Blog.Tests.Application.Features.Articles.Queries.GetArticleById;

public class GetArticleByIdQueryHandlerTest
{
    [Fact]
    public async Task ShouldGetArticleById()
    {
        var article = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Test Title",
            Content = "Test Content",
        };
        var command = new GetArticleByIdQuery { Id = article.Id };
        var handler = CreateHandler(article);
        var result = await handler.Handle(command, CancellationToken.None);
        
        Assert.Equal(article.Id, result.Id);
        Assert.Equal(article.Content, result.Content);
        Assert.Equal(article.Content, result.Content);
    }
    
    [Fact]
    public async Task ShouldThrowExceptionWhenArticleNotFound()
    {
        var article = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Test Title",
            Content = "Test Content",
        };
        var fakeId = Guid.NewGuid();
        var command = new GetArticleByIdQuery { Id = fakeId};
        var handler = CreateHandler(article);
        
        var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));
        Assert.NotNull(exception);
    }

    private static GetArticleByIdQueryHandler CreateHandler(Article article, Guid? articleId = null)
    {
        var articleReadOnlyRepository = new ArticleReadOnlyRepositoryBuilder();
        if (articleId.HasValue)
            articleReadOnlyRepository.GetArticleById(article, articleId);
        else
            articleReadOnlyRepository.GetArticleById(article);

        return new GetArticleByIdQueryHandler(articleReadOnlyRepository.Build());
    }
}