using System.ComponentModel.DataAnnotations;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, MaxLength(280)]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }
        public string TargetAudience { get; set; }
        public string Objectives { get; set; }
        public Level Requirements { get; set; }

    }

    public enum Level
    {
        Basic,
        Intermediate,
        Advanced
    }
}
