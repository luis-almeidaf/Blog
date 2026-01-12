using Blog.Domain.Entities;

namespace Blog.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}