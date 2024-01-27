using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppSqlServer.Models;
using WebAppSqlServer.Services;

namespace WebAppSqlServer.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;


        public void OnGet()
        {
            var service = new ProductService();
            products = service.GetProducts();
        }
    }
}