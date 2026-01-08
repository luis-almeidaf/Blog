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
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    async Task<Article> IArticleReadOnlyRepository.GetArticleById(Guid id)
    {
        return (await dbContext.Articles
            .AsNoTracking()
            .Include(a => a.Tags).FirstOrDefaultAsync(article => article.Id == id))!;
    }

    async Task<Article> IArticleWriteOnlyRepository.GetArticleById(Guid id)
    {
        return (await dbContext.Articles
            .Include(a => a.Tags)
            .FirstAsync(article => article.Id == id))!;
    }

    public async Task Add(Article article)
    {
        await dbContext.Articles.AddAsync(article);
    }

    public async Task Archive(Guid articleId)
    {
        var article = await dbContext.Articles.FirstOrDefaultAsync(a => articleId == a.Id);
        article!.IsArchived = true;
        dbContext.Articles.Update(article!);
    }

    public async Task Unarchive(Guid articleId)
    {
        var article = await dbContext.Articles.FirstOrDefaultAsync(a => articleId == a.Id);
        article!.IsArchived = false;
        dbContext.Articles.Update(article!);
    }

    public void Update(Article article)
    {
        dbContext.Articles.Update(article);
    }
}