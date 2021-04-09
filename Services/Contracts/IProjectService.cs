using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectDto>> GetManyAsync(Guid employeeId);
        public Task<ProjectDto> GetByIdAsync(Guid employeeId, Guid id);
        public Task<ProjectDto> CreateAsync(ProjectForCreationDto projectForCreation);
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> UpdateAsync(Guid id, ProjectForUpdateDto projectForUpdate);
    }
}