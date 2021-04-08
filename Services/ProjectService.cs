using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<ProjectService> _logger;
        private readonly IMapper _mapper;

        public ProjectService(IRepositoryManager repositoryManager, ILogger<ProjectService> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> GetManyAsync(Guid employeeId)
        {
            IEnumerable<Project> projects;

            if (!employeeId.Equals(Guid.Empty))
            {
                if (!await EmployeeExists(employeeId)) return null;
                projects = await _repositoryManager.Project.GetAllEmployeeProjectsAsync(employeeId, false);
            }
            else
                projects = await _repositoryManager.Project.GetAllProjectsAsync(false);

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }
        

        public async Task<ProjectDto> GetByIdAsync(Guid employeeId, Guid id)
        {
            Project project;

            if (!employeeId.Equals(Guid.Empty))
            {
                if (!await EmployeeExists(employeeId)) return null;
                project = await _repositoryManager.Project.GetEmployeeProjectAsync(employeeId, id, false);
            }
            else
                project = await _repositoryManager.Project.GetProjectAsync(id, false);
            
            return _mapper.Map<ProjectDto>(project);
        }

        private async Task<bool> EmployeeExists(Guid employeeId)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeAsync(employeeId, false);
            if (employee == null)
            {
                _logger.LogInformation("Employee with id {EmployeeId} doesn't exist in the db", employeeId);
                return false;
            }

            return true;
        }
    }
}