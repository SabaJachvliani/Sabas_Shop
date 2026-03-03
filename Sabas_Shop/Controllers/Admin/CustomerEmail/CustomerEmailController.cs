using Application.Common.Mail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sabas_Shop.Settings;

namespace Sabas_Shop.Controllers.Admin.CustomerEmail
{
    public class CustomerEmailController : ApiControllerBase
    {
        public CustomerEmailController(ISender sender) : base(sender) { }

        [HttpPost("SendCustomerEmail")]
        public async Task<IActionResult> Send([FromBody] SendCustomerEmailCommand request, CancellationToken ct)
        {
            await Sender.Send(request, ct);
            return Ok(new { sent = true });
        }
    }
}
