using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenFirm.API.Controllers
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

        [HttpGet("search")]
        public IActionResult GetAccounts(string? search, int page = 0, int pageSize = 10)
        {
            var query = _context.Accounts.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(a => a.TraderName.Contains(search));
            }

            //Without ordering the paging wouldn't work!
            //Becuase we could see the same items on the page multiple times
            query = query.OrderBy(a => a.Id);

            var totalItems = query.Count();
            var pages = query.Skip(page * pageSize).Take(pageSize).ToList();

            return Ok(new { data = pages, TotalItems = totalItems});
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
