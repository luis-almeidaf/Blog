using Blog.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace Blog.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncrypter
{
    public string EncryptPassword(string password) => BC.HashPassword(password);
    public bool VerifyPassword(string password, string hashedPassword) => BC.Verify(password, hashedPassword);
}