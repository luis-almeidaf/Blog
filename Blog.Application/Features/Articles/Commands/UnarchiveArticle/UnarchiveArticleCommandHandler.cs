using Blog.Application.Features.Articles.Commands.ArchiveArticle;
using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Article;
using MediatR;

namespace Blog.Application.Features.Articles.Commands.UnarchiveArticle;

public class UnarchiveArticleCommandHandler(
    IArticleWriteOnlyRepository repository, 
    IUnitOfWork unitOfWork) : IRequestHandler<UnarchiveArticleCommand, Unit>
{
    public async Task<Unit> Handle(UnarchiveArticleCommand request, CancellationToken cancellationToken)
    {
        await repository.Unarchive(request.ArticleId);

        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}