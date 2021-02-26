using DemoShopAdmin.Models;
using DemoShopAdmin.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoShopAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]//mb
        public async Task<ActionResult> Index()
        {
            return View(await _categoryService.GetAllAsync());
        }

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            return View(await _categoryService.GetAsync(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            try
            {
                await _categoryService.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            return View(await _categoryService.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category category)
        {
            try
            {
                await _categoryService.UpdateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            return View(await _categoryService.GetAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Category category)
        {
            try
            {
                await _categoryService.DeleteAsync(category);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }
    }
}
