using Blog.Application.Features.Articles.Commands.ArchiveArticle;
using Blog.Application.Features.Articles.Commands.UnarchiveArticle;
using Blog.Tests.Builders.Repositories;

namespace Blog.Tests.Application.Features.Articles.Commands.UnarchiveArticle;

public class UnarchiveArticleCommandHandlerTest
{
    [Fact]
    public async Task ShouldUnarchiveArticle()
    {
        var handler = CreateHandler();
        var command = new UnarchiveArticleCommand { ArticleId = Guid.NewGuid() };

        var exception = await Record.ExceptionAsync(async () => await handler.Handle(command, CancellationToken.None));
        Assert.Null(exception);
    }

    private static UnarchiveArticleCommandHandler CreateHandler()
    {
        var unitOfWork = UnitOfWorkBuilder.Build();
        var articleWriteOnlyRepository = new ArticleWriteOnlyRepositoryBuilder().Build();

        return new UnarchiveArticleCommandHandler(articleWriteOnlyRepository, unitOfWork);
    }
}