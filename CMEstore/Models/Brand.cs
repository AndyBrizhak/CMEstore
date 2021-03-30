using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMEstore.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Название Бренда")]
        public string Name { get; set; }

        [DisplayName("Порядок вывода на экран")]
        public int DisplayOrder { get; set; }
    }
}
