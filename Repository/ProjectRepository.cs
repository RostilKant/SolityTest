using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges) =>
            await FindAll(trackChanges)
                .OrderBy(x => x.StartDate)
                .ToListAsync();
    }
}