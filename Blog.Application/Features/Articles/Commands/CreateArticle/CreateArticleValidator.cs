using Blog.Domain.Entities;
using FluentValidation;

namespace Blog.Application.Features.Articles.Commands.CreateArticle;

public class CreateArticleValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleValidator()
    {
        RuleFor(article => article.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(article => article.Content).NotEmpty().WithMessage("Content is required");
    }
}