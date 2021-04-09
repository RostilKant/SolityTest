using System;
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

        public async Task<Project> GetProjectAsync(Guid id, bool trackChanges) =>
            await FindByCondition(x => x.Id == id, trackChanges)
                .SingleOrDefaultAsync();

        public void CreateProject(Project project) => Create(project);
        public void DeleteProject(Project project) => Delete(project);

        public async Task<IEnumerable<Project>> GetAllEmployeeProjectsAsync(Guid employeeId, bool trackChanges) =>
            await FindByCondition(x =>
                    x.Employees.Select(y => y.Id).Contains(employeeId), false)
                .ToListAsync();

        public async Task<Project> GetEmployeeProjectAsync(Guid employeeId, Guid id, bool trackChanges) =>
            await FindByCondition(x =>
                    x.Employees.Select(y => y.Id).Contains(employeeId), false)
                .SingleOrDefaultAsync(x => x.Id == id); 
    }
}