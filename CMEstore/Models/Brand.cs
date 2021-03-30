using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CMEstore.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название Бренда")]
        public string Name { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage = "Порядок отображения Бренда должен быть больше нуля")]
        [DisplayName("Порядок вывода на экран")]
        public int DisplayOrder { get; set; }
    }
}
