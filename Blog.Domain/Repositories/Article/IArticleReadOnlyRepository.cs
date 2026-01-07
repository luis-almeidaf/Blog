namespace Blog.Domain.Repositories.Article;

public interface IArticleReadOnlyRepository
{
    Task<List<Entities.Article>> GetArticles();
    Task<Entities.Article> GetArticleById(Guid id);
}