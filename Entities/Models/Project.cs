using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Project
    {
        [Column("ProjectId")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Project title is required field")]
        [MaxLength(40, ErrorMessage = "Maximum length of title is 40 characters")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Start date is required field")]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "Release date is required field")]
        public DateTime ReleaseDate { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}