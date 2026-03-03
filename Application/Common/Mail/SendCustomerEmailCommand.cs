using MediatR;

namespace Application.Common.Mail
{
    public sealed record SendCustomerEmailCommand(string To, string Subject, string HtmlBody) : IRequest<bool>;
}
