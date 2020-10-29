using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
