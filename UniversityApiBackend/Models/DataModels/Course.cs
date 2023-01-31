using System.ComponentModel.DataAnnotations;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(280)]
        public string ShortDescription { get; set; } = string.Empty;

        public string LongDescription { get; set; } = string.Empty;
        public string TargetAudience { get; set; } = string.Empty;
        public string Objectives { get; set; } = string.Empty;  
        public Level Requirements { get; set; }

    }

    public enum Level
    {
        Basic,
        Intermediate,
        Advanced
    }
}
