namespace MusicApp.Application.Security;

public interface IPasswordHasher {
    (string Hash, string Salt) HashPassword(string password);
    bool Verify(string password, string salt, string expectedHash);
}

