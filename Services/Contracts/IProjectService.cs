using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProjectService
    {
        public Task<IEnumerable<Project>> GetManyAsync();
        public Task<Project> GetByIdAsync(string id);
    }
}