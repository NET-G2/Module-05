using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson11.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255, ErrorMessage = "Subject title cannot have more than 255 characters!")]
        [MinLength(5, ErrorMessage = "Subject must have at least 5 characters!")]
        public string Name { get; set; }
        [Required]
        [Range(500, 5000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        [Range(30, 180)]
        public int NumberOfHours { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
