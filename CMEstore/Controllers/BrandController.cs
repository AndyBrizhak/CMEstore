using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            if (ModelState.IsValid)
            {
                _db.Brand.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        /// <summary>
        /// GET Request for edit Brand
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Brand.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        /// <summary>
        /// POST Request for edit Brand
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Brand obj)
        {
            if (ModelState.IsValid)
            {
                _db.Brand.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
