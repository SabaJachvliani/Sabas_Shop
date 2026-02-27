using Application.DTO.Auth;
using Application.Interfaces.Auth;
using MediatR;

namespace Application.Handlers.Admin.MeAutorization
{
    public sealed class LogginCheckHandler : IRequestHandler<LogginCheckQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUser;

        public LogginCheckHandler(IUserRepository userRepository, ICurrentUserService currentUser)
            
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public async Task<UserDTO> Handle(LogginCheckQuery request, CancellationToken cancellationToken)

        {
            if (_currentUser.UserId is null)
                throw new UnauthorizedAccessException("User is not authenticated.");
            
            var user = await _userRepository.GetByIdAsync(_currentUser.UserId.Value, cancellationToken);
            if (user is null)
                throw new UnauthorizedAccessException("User not found.");

            var roles = user.Role;

            return new UserDTO
            {
                Id = user.Id,
                Email = user.Mail,
                firstName = user.FirstName,
                lastName = user.LastName,               
                Roles = roles
            };
        }
    }
}
