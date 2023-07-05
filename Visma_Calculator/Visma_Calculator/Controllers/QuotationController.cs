using Microsoft.AspNetCore.Mvc;

namespace Visma_Calculator.Controllers
{
    public class QuotationController : Controller
    {
        public IActionResult Index(IFormCollection form)
        {
            decimal constructionAmount = Convert.ToDecimal(form["Construction Amount"]);
            decimal maxDiscountPercentage = Convert.ToDecimal(form["Max Discount Percentage"]);
            decimal maxDiscountAmount = constructionAmount * maxDiscountPercentage;

            // List of ordered items and their prices
            var orderedItems = new Dictionary<string, decimal>
            {
                { "Item 1", 100.00m },
                { "Item 2", 50.00m },
                { "Item 3", 80.00m },
                { "Item 4", 60.00m },
                { "Item 5", 70.00m }
            };

            decimal selectedItemsAmount = 0.00m;
            var selectedItems = new List<string>();

            foreach (var item in orderedItems)
            {
                if (selectedItemsAmount + item.Value <= maxDiscountAmount)
                {
                    selectedItems.Add(item.Key);
                    selectedItemsAmount += item.Value;
                }
            }

            ViewBag.MaxDiscountAmount = maxDiscountAmount;
            ViewBag.SelectedItems = selectedItems;

            return View();
        }
    }
}
