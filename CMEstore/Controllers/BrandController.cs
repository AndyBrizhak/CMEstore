using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMEstore.Data;
using CMEstore.Models;

namespace CMEstore.Controllers
{
    public class BrandController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BrandController(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Get all Brands
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IEnumerable<Brand> objList = _db.Brand;
            return View(objList);
        }

        /// <summary>
        /// GET Request for create new Brand
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }


        /// <summary>
        /// POST Request for create new Brand
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brand obj)
        {
            _db.Brand.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
