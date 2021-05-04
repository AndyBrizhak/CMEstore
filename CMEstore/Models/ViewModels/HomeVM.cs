using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMEstore.Models.ViewModels
{
    public class HomeVM
    {
        /// <summary>
        /// All Products from database 
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// All Brands from database
        /// </summary>
        public IEnumerable<Brand> Brands { get; set; }
    }
}
