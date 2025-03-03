using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0102_Metler.Models
{
    // make task table
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public string? DueDate { get; set; } // not required
        [Required]
        public int Quadrant { get; set; }
        [ForeignKey("CategoryId")] // make foreign key relationship with category table
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int Completed { get; set; } = 0;
    }

   
}
