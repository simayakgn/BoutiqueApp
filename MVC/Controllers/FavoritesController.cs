using BLL.Controllers.Bases;
using BLL.DAL;
using BLL.Models;
using BLL.Services;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class FavoritesController : MvcController
    {
        const string SESSIONKEY = "Favorites";
        private readonly HttpServiceBase _httpService;
        private readonly IService<Products, ProductModel> _productService;

        public FavoritesController(HttpServiceBase httpService, IService<Products, ProductModel> productService)
        {
            _httpService = httpService;
            _productService = productService;
        }
        private int GetUserId() => Convert.ToInt32(User.Claims.SingleOrDefault(c=> c.Type == "Id").Value);
        private List<FavoritesModel> GetSession(int userId)
        {
            var favorites = _httpService.GetSession<List<FavoritesModel>>(SESSIONKEY);
            return favorites?.Where(f => f.UserId == userId).ToList();
        }
        public IActionResult Get()
        {
            return View("List",GetSession(GetUserId()));
        }

        public IActionResult Remove(int productId)
        {
            var favorites = GetSession(GetUserId());
            var favoritesItem = favorites.FirstOrDefault(c => c.ProductId == productId);
            favorites.Remove(favoritesItem);
            _httpService.SetSession(SESSIONKEY, favorites);
            return RedirectToAction(nameof(Get));
        }

        // GET: /Favorites/Add?productId=13
        public IActionResult Add(int productId)
        {
            int userId = GetUserId();
            var favorites = GetSession(userId);
            favorites = favorites ?? new List<FavoritesModel>();
            if (!favorites.Any(f => f.ProductId == productId))
            {
                var product = _productService.Query().SingleOrDefault(p => p.Record.Id == productId);

                var favoritesItem = new FavoritesModel()
                {
                    ProductName = product.Name,
                    ProductId = product.Record.Id,
                    UserId = userId,
                    ProductPrice = product.Price,
                };
                favorites.Add(favoritesItem);
                _httpService.SetSession(SESSIONKEY, favorites);
                TempData["Message"] = $"\"{product.Name}\" added to cart.";
            }
            return RedirectToAction("Index", "Products");
        }
    }
}
