namespace Blog.Domain.Repositories.Article;

public interface IArticleWriteOnlyRepository
{
    Task Add(Entities.Article article);
}