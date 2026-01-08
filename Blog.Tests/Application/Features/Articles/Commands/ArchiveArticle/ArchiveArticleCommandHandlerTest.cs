using Blog.Application.Features.Articles.Commands.ArchiveArticle;
using Blog.Tests.Builders.Repositories;

namespace Blog.Tests.Application.Features.Articles.Commands.ArchiveArticle;

public class ArchiveArticleCommandHandlerTest
{
    [Fact]
    public async Task ShouldArchiveArticle()
    {
        var handler = CreateHandler();
        var command = new ArchiveArticleCommand{ ArticleId = Guid.NewGuid()};
        
        var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));
        Assert.Null(exception);
    }
    
    private static ArchiveArticleCommandHandler CreateHandler()
    {
        var unitOfWork = UnitOfWorkBuilder.Build();
        var articleWriteOnlyRepository = new ArticleWriteOnlyRepositoryBuilder().Build();

        return new ArchiveArticleCommandHandler(articleWriteOnlyRepository, unitOfWork);
    }
}