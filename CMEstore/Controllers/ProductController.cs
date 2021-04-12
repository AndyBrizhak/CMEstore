﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMEstore.Data;
using CMEstore.Models;

namespace CMEstore.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// GET Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Product;

            foreach (var obj in objList)
            {
                obj.Brand = _db.Brand.FirstOrDefault(u => u.Id == obj.BrandId);
            };

            return View(objList);
        }


        
        /// <summary>
        /// GET - UPSERT
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Upsert(int? id)
        {
            Product product = new Product();
            if (id == null)
            {
                //this is for create
                return View(product);
            }

            product = _db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        /// <summary>
        /// POST - UPSERT
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Brand obj)
        {
            if (ModelState.IsValid)
            {
                _db.Brand.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        /// <summary>
        /// GET - DELETE
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
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

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Brand.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Brand.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

    }
}

