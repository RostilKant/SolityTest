using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees(bool trackChanges);
    }
}