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

        public ViewResult Index(string category, int productPage = 1)
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
                    .Where(p => category == null || p.Category == category)
                    .Skip((productPage - 1) * pageSize)
                    .Take(pageSize)
            };

            return View(model);
        }
    }
}
