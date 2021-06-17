using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        int pageSize = 4;
        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IActionResult Index(int productPage = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = pageSize,
                    TotalItems = _storeRepository.Products.Count()
                },
                Products = _storeRepository.Products
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * pageSize)
                    .Take(pageSize)
            };

            return View(model);
        }
    }
}
