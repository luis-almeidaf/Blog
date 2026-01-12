using Blog.Domain.Repositories;
using Blog.Domain.Repositories.Article;
using Blog.Domain.Repositories.User;
using Blog.Domain.Security.Cryptography;
using Blog.Domain.Security.Tokens;
using Blog.Infrastructure.DataAccess;
using Blog.Infrastructure.DataAccess.Repositories;
using Blog.Infrastructure.Security.Token;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddBcrypt(services);
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddToken(services, configuration);
    }
    
    private static void AddBcrypt(IServiceCollection services)
    {
        services.AddScoped<IPasswordEncrypter, Security.Cryptography.BCrypt>();
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BlogDbContext>(options => options.UseNpgsql(connectionString));
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");
        
        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IArticleWriteOnlyRepository, ArticleRepository>();
        services.AddScoped<IArticleReadOnlyRepository, ArticleRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}