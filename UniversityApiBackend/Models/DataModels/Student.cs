using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace UniversityApiBackend.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public String Lastname { get; set; } = String.Empty;
        [Required]
        public DateTime Dob { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
