using System;

namespace Entities.DataTransferObjects
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        
        public string FullName { get; set; }
     
        public string Job { get; set; }
        
        public DateTime EmploymentDate { get; set; }
    }
}