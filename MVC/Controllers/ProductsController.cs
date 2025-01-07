using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BLL.Controllers.Bases;
using BLL.Services.Bases;
using BLL.Models;
using BLL.DAL;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;



// Generated from Custom Template.

namespace MVC.Controllers
{
    [Authorize]
    public class ProductsController : MvcController
    {
        // Service injections:
        private readonly IService<Products, ProductModel> _productsService;
        private readonly ICategoryService _categoryService;

        /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
        private readonly IService<Customer, CustomerModel> _customerService;

        public ProductsController(
			IService<Products, ProductModel> productsService
            , ICategoryService categoryService

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            , IService<Customer, CustomerModel> customerService
        )
        {
            _productsService = productsService;
            _categoryService = categoryService;

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            _customerService = customerService;
        }

        // GET: Products
        [AllowAnonymous]
        public IActionResult Index()
        {
            // Get collection service logic:
            var list = _productsService.Query().ToList();
            return View(list);
        }

        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            // Get item service logic:
            var item = _productsService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        protected void SetViewData()
        {
            // Related items service logic to set ViewData (Record.Id and Name parameters may need to be changed in the SelectList constructor according to the model):
            ViewData["CategoryId"] = new SelectList(_categoryService.Query().ToList(), "Record.Id", "Name");

            /* Can be uncommented and used for many to many relationships. {Entity} may be replaced with the related entiy name in the controller and views. */
            ViewBag.CustomerIds = new SelectList(_customerService.Query().ToList(), "Record.Id", "NameAndSurname");
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductModel products)
        {
            if (ModelState.IsValid)
            {
                // Insert item service logic:
                var result = _productsService.Create(products.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = products.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(products);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            // Get item to edit service logic:
            var item = _productsService.Query().SingleOrDefault(q => q.Record.Id == id);
            SetViewData();
            return View(item);
        }

        // POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(ProductModel products)
        {
            if (ModelState.IsValid)
            {
                // Update item service logic:
                var result = _productsService.Update(products.Record);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Details), new { id = products.Record.Id });
                }
                ModelState.AddModelError("", result.Message);
            }
            SetViewData();
            return View(products);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            // Get item to delete service logic:
            var item = _productsService.Query().SingleOrDefault(q => q.Record.Id == id);
            return View(item);
        }

        // POST: Products/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Delete item service logic:
            var result = _productsService.Delete(id);
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
	}
}
