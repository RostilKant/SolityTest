using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetManyAsync();
        public Task<Employee> GetByIdAsync(string id);
    }
}