using Entities;
using Entities.Models;
using Repository.Contracts;

namespace Repository
{
    public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }
    }
}