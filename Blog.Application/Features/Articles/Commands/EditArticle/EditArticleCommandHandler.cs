using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Article;
using MediatR;

namespace Blog.Application.Features.Articles.Commands.EditArticle;

public class EditArticleCommandHandler(
    IArticleWriteOnlyRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<EditArticleCommand, Unit>
{
    public async Task<Unit> Handle(EditArticleCommand request, CancellationToken cancellationToken)
    {
        var article = await repository.GetArticleById(request.ArticleId);

        article.Title = request.Title;
        article.Content = request.Content;
        article.UpdatedAt = DateTime.UtcNow;

        article.Tags.Clear();
        var tagNames = request.TagNames ?? [];

        foreach (var tagName in tagNames)
        {
            article.Tags.Add(new Tag
            {
                Name = tagName,
                ArticleId = article.Id
            });
        }

        repository.Update(article);
        await unitOfWork.CommitAsync();

        return Unit.Value;
    }
}