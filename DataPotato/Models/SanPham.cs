using System.ComponentModel.DataAnnotations;

namespace DataPotato.Models
{
    public class SanPham
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Name { get; set; }
        public string ImgURL { get; set; }
    }
}
