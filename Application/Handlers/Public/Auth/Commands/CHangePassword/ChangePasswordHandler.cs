using Application.Interfaces.Auth;
using Application.Interfaces.Infrastructure;
using MediatR;

namespace Application.Handlers.Public.Auth.Commands.CHangePassword
{
    public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, string>
    {
        public readonly ISabaShopDb _db;       
        private readonly IUserRepository _users;
        private readonly IPasswordService _passwords;

        public ChangePasswordHandler(ISabaShopDb db, IUserRepository users, IPasswordService passwords)
        {
            _db = db;
            _users = users;
            _passwords = passwords;
        }

        public async Task<string> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var email = request.Mail.Trim().ToLower();
            var user = await _users.GetByEmailAsync(email, cancellationToken);
            if (user == null)
            {
                throw new Exception("ther is no such costumer");
            }

            var isPasswordValid = _passwords.Verify(request.Password, user.PasswordHash);

            if (isPasswordValid == false)
            {
                throw new Exception("Enter Valid Password");
            }

            user.PasswordHash = _passwords.Hash(request.NewPassword);
            _db.Costumers.Update(user);            
            await _db.SaveChangesAsync(cancellationToken);


            return "password changed";
        }
    }
}
