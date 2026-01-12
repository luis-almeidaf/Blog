namespace Blog.Application.Features.Auth.Commands.Login;

public class LoginResponse
{
    public bool Success { get; init; }
    public string? Error { get; set; }
    public string? Token { get; set; } = string.Empty;

    public static LoginResponse Fail(string error) => new LoginResponse { Success = false, Error = error };
    public static LoginResponse Valid(string token) => new LoginResponse { Success = true, Token = token };
}