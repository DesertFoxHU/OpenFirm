using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenFirm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PropFirmContext _context;

        public AccountController(PropFirmContext context)
        {
            _context = context;
        }

        [HttpPost("start-challange")]
        public IActionResult StartChallange(string traderName, decimal startingCapital)
        {
            var newAccount = new Account()
            {
                TraderName = traderName,
                InitialBalance = startingCapital,
                Balance = startingCapital,
                Status = AccountStatus.Evaulation
            };
            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
            return Ok(newAccount);
        }
    }
}
