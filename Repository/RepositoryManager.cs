using System.Threading.Tasks;
using Entities;
using Repository.Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationContext _applicationContext;

        private IEmployeeRepository _employeeRepository;
        private IProjectRepository _projectRepository;

        public RepositoryManager(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEmployeeRepository Employee 
            => _employeeRepository ??= new EmployeeRepository(_applicationContext);
        
        public IProjectRepository Project 
            => _projectRepository ??= new ProjectRepository(_applicationContext);

        public Task SaveAsync() => _applicationContext.SaveChangesAsync();
    }
}