using Blog.Domain.Entities;
using Blog.Domain.Repositories.Article;
using Moq;

namespace Blog.Tests.Builders.Repositories;

public class ArticleReadOnlyRepositoryBuilder
{
    private readonly Mock<IArticleReadOnlyRepository> _repository = new();

    public ArticleReadOnlyRepositoryBuilder GetArticleById(Article article, Guid? articleId = null)
    {
        if (articleId.HasValue)
            _repository.Setup(repo => repo.GetArticleById(articleId.Value))!.ReturnsAsync((Article?)null);
        else
            _repository.Setup(repo => repo.GetArticleById(article.Id))!.ReturnsAsync(article);

        return this;
    }

    public ArticleReadOnlyRepositoryBuilder GetArticles(Article? article = null)
    {
        if (article is not null)
            _repository.Setup(repo => repo.GetArticles())!.ReturnsAsync([article]);
        else
            _repository.Setup(repo => repo.GetArticles())!.ReturnsAsync([]);

        return this;
    }

    public IArticleReadOnlyRepository Build() => _repository.Object;
}