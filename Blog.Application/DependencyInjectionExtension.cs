using System.Reflection;
using Blog.Application.Features.Articles.Commands.CreateArticle;
using Blog.Application.Features.Articles.Commands.EditArticle;
using Blog.Application.Features.Auth.Commands.RegisterUserCommand;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddSingleton<IValidator<CreateArticleCommand>, CreateArticleValidator>();
        services.AddSingleton<IValidator<EditArticleViewModel>, EditArticleValidator>();
        services.AddSingleton <IValidator<RegisterUserCommand>, RegisterUserValidator>();
    }
}