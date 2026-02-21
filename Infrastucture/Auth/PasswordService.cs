using Application.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;

namespace Infrastucture.Auth
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<object> _hasher = new();
        public string Hash(string password)
        {
            return _hasher.HashPassword(new object(), password);
           
        }

        public bool Verify(string password, string hash)
        {
           return _hasher.VerifyHashedPassword(new object(), hash, password)
                  == PasswordVerificationResult.Success;
        }
    }
}
