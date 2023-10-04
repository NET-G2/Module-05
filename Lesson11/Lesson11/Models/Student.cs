using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson11.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Age { get; set; }
        [Required(ErrorMessage = "Full Name is required!")]
        [MaxLength(250, ErrorMessage = "Name should be less than 250 characters.")]
        public string FullName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public override string ToString()
        {
            return $"Id {Id}, Name {FullName}";
        }
    }
}
