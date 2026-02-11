using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenFirm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradingController : ControllerBase
    {
        private readonly PropFirmContext _context;

        public TradingController(PropFirmContext context)
        {
            _context = context;
        }

        [HttpGet("{accountId}")]
        public IActionResult GetTradesByAccount(int accountId)
        {
            var trades = _context.Trades
                .Where(t => t.AccountId == accountId)
                .OrderByDescending(t => t.Date)
                .ToList();
            return Ok(trades);
        }

        [HttpPost]
        public IActionResult AddTrade(Trade newTrade)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == newTrade.AccountId);

            if (account == null)
            {
                return NotFound("Account not found.");
            }

            if(account.Status == AccountStatus.Failed)
            {
                return BadRequest("This account is failed.");
            }

            return Ok("");
        }
    }
}
