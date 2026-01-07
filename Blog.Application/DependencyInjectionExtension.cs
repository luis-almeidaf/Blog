using System.Reflection;
using Blog.Application.Features.Articles.Commands.CreateArticle;
using Blog.Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddSingleton<IValidator<CreateArticleCommand>, CreateArticleValidator>();
    }
}