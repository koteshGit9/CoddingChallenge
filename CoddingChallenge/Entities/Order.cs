using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoddingChallenge.Entities
{
    public class Order
    {
    [Key]
     public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public User User { get; set; }
    }
}
