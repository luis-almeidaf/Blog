using Blog.Domain.Repositories;
using Blog.Domain.Repositories.User;
using Blog.Domain.Security.Cryptography;
using Blog.Domain.Security.Tokens;
using MediatR;

namespace Blog.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler(
    IAccessTokenGenerator tokenGenerator,
    IPasswordEncrypter passwordEncrypter,
    IUserReadOnlyRepository userRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<LoginCommand, LoginResponse>
{
    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmail(request.Email);
        if (user == null) return LoginResponse.Fail("User not found");
        
        var passwordMatch = passwordEncrypter.VerifyPassword(request.Password, user.Password);
        if (!passwordMatch) return LoginResponse.Fail("Email or password incorrect");

        await unitOfWork.CommitAsync();

        return LoginResponse.Valid(tokenGenerator.Generate(user));

    }
}