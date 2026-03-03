namespace Infrastucture.Mail
{
    public sealed class EmailSettings
    {
        public string Host { get; init; } = default!;
        public int Port { get; init; } = 587;

        public string User { get; init; } = default!;
        public string Password { get; init; } = default!;

        public string FromEmail { get; init; } = default!;
        public string FromName { get; init; } = "Shop";

        public bool UseStartTls { get; init; } = true;
    }
}
