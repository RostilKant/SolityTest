using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    [Index(nameof(FirstName), nameof(LastName), IsUnique = true)]
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "First name is required field")]
        [MaxLength(40, ErrorMessage = "Maximum length of name is 40 characters")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required field")]
        [MaxLength(40, ErrorMessage = "Maximum length of name is 40 characters")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Job is required field")]
        [MaxLength(30, ErrorMessage = "Maximum length of job title is 30 characters")]
        public string Job { get; set; }
        
        [Required(ErrorMessage = "Employment date is required field")]
        public DateTime EmploymentDate { get; set; }
        
        public ICollection<Project> Projects {get;set;}
    }
}