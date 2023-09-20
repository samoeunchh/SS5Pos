using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS5Pos.Data;
using SS5Pos.Repository;

namespace SS5Pos.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _sale;
        private readonly AppDbContext _context;
        public SaleController(ISaleService sale,
            AppDbContext context)
        {
            _sale = sale;
            _context = context;
        }
        // GET: Sale
        public async Task<IActionResult> Index()
        {
            return View(await _sale.GetSales());
        }
        public async Task<JsonResult> GetProduct(string barcode)
            => Json(await _context.Proeduct.Where(x => x.Barcode!.Equals(barcode)).FirstOrDefaultAsync());
        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sale/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Customer"]= new SelectList(_context.Customer, "CustomerId", "CustomerName");
            ViewData["CategoryList"] = await _context.Category.ToListAsync();
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sale/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sale/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}