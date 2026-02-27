namespace Application.DTO.Auth
{  
    public sealed class UserDTO
    {
        public long Id { get; init; }
        public string Email { get; init; } = null!;
        public string firstName { get; init; } = null!;
        public string lastName { get; init; } = null!;       
        public string Roles { get; init; } 
    }
}





