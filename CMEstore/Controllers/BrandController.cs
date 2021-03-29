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

        public IActionResult Index()
        {
            IEnumerable<Brand> objList = _db.Brand;
            return View(objList);
        }
    }
}
