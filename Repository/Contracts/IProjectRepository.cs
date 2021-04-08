using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository.Contracts
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges);
    }
}