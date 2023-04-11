using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MummyNation_Team0113.Models;

namespace MummyNation_Team0113.Views.Pages
{
    public class MummySummaryModel : PageModel
    {
        private IMummyNation_Team0113Repository repo { get; set; }
        public MummySummaryModel(IMummyNation_Team0113Repository temp)
        {
            repo = temp;
        }
        
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            // cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); being handled in startup instead
        }

        public IActionResult OnPost(int burialId, string returnUrl)
        {
            Burialmain b = repo.burialmain.FirstOrDefault(x => x.Id == burialId);
            // cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); // if cart already exists, else make a new one

            // HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        //public IActionResult OnPostRemove(int bookId, string returnUrl)
        //{
        //    cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);

        //    return RedirectToPage(new { ReturnUrl = returnUrl });
        //}
    }
}
