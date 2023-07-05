using Microsoft.AspNetCore.Mvc;

namespace Visma_Calculator.Controllers
{

    public class LedgerAccount
    {
        public string? AccountName { get; set; }
        public decimal Balance { get; set; }
    }

    public class LedgerController : Controller
    {
        public IActionResult Index()
        {
            List<LedgerAccount> ledgerAccounts = new List<LedgerAccount>
            {
                new LedgerAccount { AccountName = "Product Group 1", Balance = 100.50m },
                new LedgerAccount { AccountName = "Product Group 2", Balance = 250.75m },
                new LedgerAccount { AccountName = "Product Group 3", Balance = 50.25m }
            };
            
            decimal totalTurnover = ledgerAccounts.Sum(account => account.Balance);
            
            ViewBag.TotalTurnover = totalTurnover;

            return View();
        }
    }
}
