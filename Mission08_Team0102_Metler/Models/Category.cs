using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0102_Metler.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
