namespace Blog.Domain.Security.Cryptography;

public interface IPasswordEncrypter
{
    string EncryptPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}