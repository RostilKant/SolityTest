using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryManager
    {
        IEmployeeRepository Employee { get; }
        IProjectRepository Project { get; }
        
        Task SaveAsync();
    }
}