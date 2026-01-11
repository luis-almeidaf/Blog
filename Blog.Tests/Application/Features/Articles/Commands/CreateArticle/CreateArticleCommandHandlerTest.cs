using Blog.Application.Features.Articles.Commands.CreateArticle;
using Blog.Tests.Builders.Repositories;

namespace Blog.Tests.Application.Features.Articles.Commands.CreateArticle;

public class CreateArticleCommandHandlerTest
{
    [Fact]
    public async Task ShouldCreateArticle()
    {
        var command = new CreateArticleCommand
        {
            Title = "Test Title",
            Summary = "Test Summary",
            Content = "Test Content",
            TagNames = ["Tag1, Tag2,Tag3"]
        };
        var handler = CreateHandler();
        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.NotEqual(Guid.Empty, result.Id);
    }
    
    private static CreateArticleCommandHandler CreateHandler()
    {
        var unitOfWork = UnitOfWorkBuilder.Build();
        var articleWriteOnlyRepository = new ArticleWriteOnlyRepositoryBuilder().Build();

        return new CreateArticleCommandHandler(articleWriteOnlyRepository, unitOfWork);
    }
}