using Blog.Domain.Entities;
using Blog.Domain.Repositories.Article;

namespace Blog.Infrastructure.DataAccess.Repositories;

public class ArticleWriteOnlyRepository(BlogDbContext dbContext) : IArticleWriteOnlyRepository
{
    public async Task Add(Article article)
    {
        await dbContext.Articles.AddAsync(article);
    }
}