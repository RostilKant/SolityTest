using Entities;
using Entities.Models;
using Repository.Contracts;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationContext applicationContext) 
            : base(applicationContext)
        {
        }
    }
}