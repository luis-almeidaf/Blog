using MediatR;

namespace Blog.Application.Features.Auth.Commands.RegisterUserCommand;

public class RegisterUserCommand : IRequest<RegisterUserResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Roles { get; private set; } =  Domain.Entities.Roles.Reader;
}