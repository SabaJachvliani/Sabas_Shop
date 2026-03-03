using MediatR;

namespace Application.Common.Mail
{
    public sealed class SendCustomerEmailHandler : IRequestHandler<SendCustomerEmailCommand, bool>
    {
        private readonly IEmailSender _email;

        public SendCustomerEmailHandler(IEmailSender email) => _email = email;

        public async Task<bool> Handle(SendCustomerEmailCommand request, CancellationToken ct)
        {
            await _email.SendAsync(
                new EmailMessage(request.To, request.Subject, request.HtmlBody),
                ct
            );
            return true;
        }
        
    }
}
