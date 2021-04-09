using System;

namespace Entities.DataTransferObjects
{
    public class EmployeeForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}