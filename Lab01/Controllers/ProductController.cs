using Microsoft.AspNetCore.Mvc;
using WebVerification.Models;

namespace WebVerification.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>() {
            new Product{ID=1, Name="Ipad", Price = 1000},
            new Product{ID=2, Name="Iphone", Price = 2000},
            new Product{ID=3, Name="IPod", Price = 4000},
        };

        public IActionResult Index() => View();

        public IActionResult ShowAll() => View(products);

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ID = products.Max(p => p.ID) + 1; 
                products.Add(product);
                return RedirectToAction("ShowAll");
            }
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            Product p = products.SingleOrDefault(q => q.ID == id);
            return p != null ? View(p) : NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Name,Price")] Product product)
        {
            if (id != product.ID)
                return BadRequest();

            if (ModelState.IsValid)
            {
                Product existing = products.SingleOrDefault(q => q.ID == id);
                if (existing != null)
                {
                    existing.Name = product.Name;
                    existing.Price = product.Price;
                }
                return RedirectToAction("ShowAll");
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            Product p = products.SingleOrDefault(q => q.ID == id);
            if (p != null)
                products.Remove(p);
            return RedirectToAction("ShowAll");
        }
    }
}
