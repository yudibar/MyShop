using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Contracts;
using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;


namespace MyShop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IRepository<Product> context;
        public ProductManagerController(IRepository<Product> productContext)
        {
            context = productContext;
        }
        public IActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            Product product = new Product();
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);
                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(string Id)
        {
            Product product = context.Find(Id);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]

        public IActionResult Edit(Product product, string Id)
        {
            Product productToEdit = context.Find(Id);
            if (productToEdit == null)
            {
                return NotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                productToEdit.Category = product.Category;
                productToEdit.Description = product.Description;
                productToEdit.Image = product.Image;
                productToEdit.Name = product.Name;

                context.Commit();
                return RedirectToAction("Index");
            }
        }

        public IActionResult Delete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if(productToDelete == null)
            {
                return NotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);
            if (productToDelete == null)
            {
                return NotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }


    }
}