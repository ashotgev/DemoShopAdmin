using DemoShopAdmin.Models;
using DemoShopAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoShopAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()//mb
        {

            return View(await _productService.GetAllAsync());
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            return View(await _productService.GetAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name,Description,Price,OldPrice,Count,SKU,CategoryId")] Product product)
        {
            try
            {
                await _productService.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name",product.CategoryId);
                return View(product);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
            return View(await _productService.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            try
            {
                await _productService.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["Categories"] = new SelectList(await _categoryService.GetAllAsync(), "Id", "Name",product.CategoryId);
                return View(product);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            return View(await _productService.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Product product)
        {
            try
            {
                await _productService.DeleteAsync(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }
    }
}
