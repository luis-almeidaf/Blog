using Blog.Domain.Entities;
using Blog.Domain.Repositories.Article;
using Moq;

namespace Blog.Tests.Builders.Repositories;

public class ArticleWriteOnlyRepositoryBuilder
{
    private readonly Mock<IArticleWriteOnlyRepository> _repository = new();

    public ArticleWriteOnlyRepositoryBuilder GetArticleById(Article article, Guid? articleId = null)
    {
        if (articleId.HasValue)
            _repository.Setup(repo => repo.GetArticleById(articleId.Value))!.ReturnsAsync((Article?)null);
        else
            _repository.Setup(repo => repo.GetArticleById(article.Id))!.ReturnsAsync(article);

        return this;
    }

    public IArticleWriteOnlyRepository Build() => _repository.Object;
}