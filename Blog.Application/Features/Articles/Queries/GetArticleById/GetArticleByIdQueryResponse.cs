using Blog.Domain.Entities;

namespace Blog.Application.Features.Articles.Queries.GetArticleById;

public class GetArticleByIdQueryResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Tag> Tags { get; set; } = [];
}