using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoddingChallenge.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(50)]
        [Required]
        public string? Name { get; set; }
        public double? Price { get; set; }
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }
        public User User { get; set; }
    }
}
