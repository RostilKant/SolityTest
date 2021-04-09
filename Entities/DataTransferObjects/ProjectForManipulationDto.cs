using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public abstract class ProjectForManipulationDto
    {
        [Required(ErrorMessage = "Project title is required field")]
        [MaxLength(40, ErrorMessage = "Maximum length of title is 40 characters")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Start date is required field")]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "Release date is required field")]
        public DateTime ReleaseDate { get; set; }
    }
}