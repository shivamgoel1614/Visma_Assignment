using Microsoft.AspNetCore.Mvc;

namespace Visma_Calculator.Controllers
{
    public class PriceAgreementController : Controller
    {
        public IActionResult Index(IFormCollection form)
        {
            try
            {
                decimal totalAmount = Convert.ToDecimal(form["Total Amount"]);
                decimal vatPercentage = Convert.ToDecimal(form["VAT Percentage"]);
                int quantity = Convert.ToInt32(form["Quantity"]);
                decimal pricePerItem = 0;
                decimal roundingDifference = 0;
                decimal amountExVat = totalAmount / (1 + vatPercentage);

                if(quantity > 0)
                    pricePerItem = amountExVat / quantity;
                    roundingDifference = pricePerItem * quantity * (1 + vatPercentage) - totalAmount;

                ViewBag.AmountExVat = amountExVat;
                ViewBag.PricePerItem = pricePerItem;
                ViewBag.RoundingDifference = roundingDifference;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
