using FluentValidation;

namespace Blog.Application.Features.Articles.Commands.EditArticle;

public class EditArticleValidator : AbstractValidator<EditArticleViewModel>
{
    public EditArticleValidator()
    {
        RuleFor(article => article.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(article => article.Content).NotEmpty().WithMessage("Content is required");
    }
}