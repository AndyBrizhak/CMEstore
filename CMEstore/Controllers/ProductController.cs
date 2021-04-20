using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CMEstore.Data;
using CMEstore.Models;
using CMEstore.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMEstore.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
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
            //IEnumerable<SelectListItem> BrandDropDown = _db.Brand.Select(i => new SelectListItem
            //{
            //    Text = i.Name,
            //    Value = i.Id.ToString()
            //});

            //ViewBag.BrandDropDown = BrandDropDown;
            //ViewData["BrandDropDown"] = BrandDropDown;

            //Product product = new Product();

            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                BrandSelectList = _db.Brand.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };


            if (id == null)
            {
                //this is for create
                return View(productVM);
            }

            productVM.Product = _db.Product.Find(id);
            if (productVM.Product == null)
            {
                return NotFound();
            }
            return View(productVM);
        }

        /// <summary>
        /// POST - UPSERT
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                if (productVM.Product.Id == 0)
                {
                    //Creating
                    string upload = webRootPath + WC.ImagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    productVM.Product.Image = fileName + extension;

                    _db.Product.Add(productVM.Product);
                }
                else
                {
                    //updating
                }

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
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

