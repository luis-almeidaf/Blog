using Blog.Domain.Entities;
using Blog.Domain.Repositories;
using Blog.Domain.Repositories.User;
using Blog.Domain.Security.Cryptography;
using Blog.Domain.Security.Tokens;
using MediatR;

namespace Blog.Application.Features.Auth.Commands.RegisterUserCommand;

public class RegisterUserCommandHandler(
    IPasswordEncrypter passwordEncrypter,
    IAccessTokenGenerator tokenGenerator,
    IUserWriteOnlyRepository userRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Password = request.Password,
            Role = request.Roles
        };

        user.Password = passwordEncrypter.EncryptPassword(request.Password);
        await userRepository.Add(user);
        await unitOfWork.CommitAsync();

        return new RegisterUserResponse { Token = tokenGenerator.Generate(user) };
    }
}