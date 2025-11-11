using System.Security.Cryptography;
using MusicApp.Application.Security;

namespace MusicApp.Infrastructure.Security;

public sealed class PasswordHasher : IPasswordHasher {
    private const int SaltSize = 16;   // 128-bit
    private const int KeySize = 32;    // 256-bit
    private const int Iterations = 100_000;
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

    public (string Hash, string Salt) HashPassword(string password) {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hashBytes = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, KeySize);
        return (Convert.ToBase64String(hashBytes), Convert.ToBase64String(salt));
    }

    public bool Verify(string password, string salt, string expectedHash) {
        var saltBytes = Convert.FromBase64String(salt);
        var computed = Rfc2898DeriveBytes.Pbkdf2(password, saltBytes, Iterations, Algorithm, KeySize);
        var expected = Convert.FromBase64String(expectedHash);
        return CryptographicOperations.FixedTimeEquals(computed, expected);
    }
}

