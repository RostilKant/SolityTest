using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository.Contracts
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync(bool trackChanges);
        Task<Project> GetProjectAsync(Guid id, bool trackChanges);
        void CreateProject(Project project);
        void DeleteProject(Project project);

        Task<IEnumerable<Project>> GetAllEmployeeProjectsAsync(Guid employeeId, bool trackChanges);
        Task<Project> GetEmployeeProjectAsync(Guid employeeId, Guid id, bool trackChanges);
    }
}