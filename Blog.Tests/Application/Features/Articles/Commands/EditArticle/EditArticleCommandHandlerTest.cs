using Blog.Application.Features.Articles.Commands.EditArticle;
using Blog.Domain.Entities;
using Blog.Tests.Builders.Repositories;

namespace Blog.Tests.Application.Features.Articles.Commands.EditArticle;

public class EditArticleCommandHandlerTest
{
    [Fact]
    public async Task ShouldEditArticle()
    {
        var article = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Test Title",
            Summary =  "Test Summary",
            Content = "Test Content",
        };

        var command = new EditArticleCommand()
        {
            ArticleId =  article.Id,
            Title = "New Title",
            Summary =  "New Summary",
            Content = "New Content",
            TagNames = ["Tag1, Tag2,Tag3"]
        };
        var handler = CreateHandler(article);

        var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));
        Assert.Null(exception);
    }
    
    [Fact]
    public async Task ShouldThrowExceptionWhenArticleIsNotFound()
    {
        var article = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Test Title",
            Summary =  "Test Summary",
            Content = "Test Content",
        };

        var command = new EditArticleCommand()
        {
            ArticleId =  article.Id,
            Title = "New Title",
            Content = "New Content",
            Summary =  "New Summary",
            TagNames = ["Tag1, Tag2,Tag3"]
        };
        var fakeGuid = Guid.NewGuid();
        var handler = CreateHandler(article, fakeGuid);

        var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));
        Assert.NotNull(exception);
    }


    private static EditArticleCommandHandler CreateHandler(Article article, Guid? articleId = null)
    {
        var unitOfWork = UnitOfWorkBuilder.Build();
        var articleWriteOnlyRepository = new ArticleWriteOnlyRepositoryBuilder();

        if (articleId.HasValue)
            articleWriteOnlyRepository.GetArticleById(article, articleId);
        else
            articleWriteOnlyRepository.GetArticleById(article);

        return new EditArticleCommandHandler(articleWriteOnlyRepository.Build(), unitOfWork);
    }
}