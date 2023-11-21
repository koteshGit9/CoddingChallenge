using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoddingChallenge.Entities
{
    public class User
    {
        [Key] 
        [StringLength(5)]
        public string? UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string? Email { get; set; }
        [Required]
        [StringLength(10)]
        public string? Password { get; set; }
        [Required]
        [StringLength(10)]
        public string? Role { get; set; }
    }
}
