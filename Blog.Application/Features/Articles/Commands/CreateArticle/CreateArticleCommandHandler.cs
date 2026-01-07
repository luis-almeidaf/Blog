using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Article;
using MediatR;

namespace Blog.Application.Features.Articles.Commands.CreateArticle;

public class CreateArticleCommandHandler(
    IArticleWriteOnlyRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateArticleCommand, CreateArticleResponse>
{
    public async Task<CreateArticleResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var newArticle = new Article
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Content = request.Content,
        };

        var tagNames = request.TagNames ?? [];

        foreach (var tagName in tagNames)
        {
            newArticle.Tags.Add(new Tag
            {
                Id = Guid.NewGuid(),
                Name = tagName,
                ArticleId = newArticle.Id
            });
        }

        await repository.Add(newArticle);

        await unitOfWork.CommitAsync();

        return new CreateArticleResponse
        {
            Id = newArticle.Id,
            Title = newArticle.Title,
            CreatedAt = newArticle.CreatedAt
        };
    }
}