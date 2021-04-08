using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectDto>> GetManyAsync();
        public Task<Project> GetByIdAsync(string id);
    }
}