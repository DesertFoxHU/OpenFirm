using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenFirm.API.Controllers
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
        public IActionResult RecordClosedTrade(Trade newTrade)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == newTrade.AccountId);

            if (account == null)
            {
                return NotFound(new { message = "Account not found."});
            }

            if(account.Status == AccountStatus.Failed)
            {
                return BadRequest(new { message = "This account is failed." });
            }

            account.Balance += newTrade.Profit;
            decimal maxLoss = account.InitialBalance * 0.9m;

            _context.Trades.Add(newTrade);
            _context.SaveChanges();

            if (account.Balance < maxLoss)
            {
                account.Status = AccountStatus.Failed;
                return Ok(new { message = "Trade recorder.", currentBalance = account.Balance, status = "Failed"});
            }

            return Ok(new { 
                message = "Trade executed successfully.",
                newBalance = account.Balance,
                status = account.Status.ToString()
            });
        }
    }
}
