using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Article;
using MediatR;

namespace Blog.Application.Features.Articles.Commands.ArchiveArticle;

public class ArchiveArticleCommandHandler(
    IArticleWriteOnlyRepository repository, 
    IUnitOfWork unitOfWork) : IRequestHandler<ArchiveArticleCommand, Unit>
{
    public async Task<Unit> Handle(ArchiveArticleCommand request, CancellationToken cancellationToken)
    {
        await repository.Archive(request.ArticleId);

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}