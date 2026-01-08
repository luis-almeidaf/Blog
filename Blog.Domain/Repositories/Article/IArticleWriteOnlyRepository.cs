namespace Blog.Domain.Repositories.Article;

public interface IArticleWriteOnlyRepository
{
    Task Add(Entities.Article article);
    Task<Entities.Article> GetArticleById(Guid id);
    Task Archive(Guid articleId);
    Task Unarchive(Guid articleId);
    void Update(Entities.Article article);
}