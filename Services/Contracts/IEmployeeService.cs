using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeDto>> GetManyAsync();
        public Task<Employee> GetByIdAsync(string id);
    }
}