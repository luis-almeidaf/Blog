using Blog.Domain.Entities;
using Blog.Domain.Repositories.Article;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DataAccess.Repositories;

public class ArticleRepository(BlogDbContext dbContext) : IArticleReadOnlyRepository, IArticleWriteOnlyRepository
{
    public async Task<List<Article>> GetArticles()
    {
        return await dbContext.Articles
            .AsNoTracking()
            .Where(a => a.IsDeleted == false).ToListAsync();
    }

    public async Task<Article> GetArticleById(Guid id)
    {
        return (await dbContext.Articles
            .AsNoTracking()
            .Include(a => a.Tags)
            .FirstOrDefaultAsync(article => article.Id == id))!;
    }

    public async Task Add(Article article)
    {
        await dbContext.Articles.AddAsync(article);
    }
}