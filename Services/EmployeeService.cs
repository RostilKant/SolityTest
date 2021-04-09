using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Enums;
using Entities.Models;
using Microsoft.Extensions.Logging;
using Repository.Contracts;
using Services.Contracts;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repositoryManager, ILogger<EmployeeService> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<IEnumerable<EmployeeDto>> GetManyAsync()
        {
            var employees = await _repositoryManager.Employee.GetAllEmployees(false);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeAsync(id, false);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeForCreationDto employeeForCreation)
        {
            var employee = _mapper.Map<Employee>(employeeForCreation);
            
            _repositoryManager.Employee.CreateEmployee(employee);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeAsync(id, false);
            
            _repositoryManager.Employee.DeleteEmployee(employee);
            await _repositoryManager.SaveAsync();
            
            return employee != null;
        }

        public async Task<bool> UpdateAsync(Guid id, EmployeeForUpdateDto employeeForUpdate)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeAsync(id, true);
            _mapper.Map(employeeForUpdate, employee);
            await _repositoryManager.SaveAsync();
            
            return employee != null;
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectsAsync(Guid id)
        {
            var projects = await _repositoryManager.Project.GetAllEmployeeProjectsAsync(id, false);

            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<bool> ManipulateProjectAsync(Guid id, ProjectAssignManipulationDto projectAssignManipulationDto)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeAsync(id, true);
            var project = await _repositoryManager.Project.GetProjectAsync(projectAssignManipulationDto.Id, true);
            
            if (project == null || employee == null)
                return false;

            switch (projectAssignManipulationDto.AssignType)
            {
                case AssignType.Adding when employee.Projects.Contains(project):
                    _logger.LogWarning($"Project with id {project.Id} is already exists");
                    return false;
                case AssignType.Removing when !employee.Projects.Contains(project):
                    _logger.LogWarning($"Project with id {project.Id} doesn't exist");
                    return false;
                case AssignType.Adding:
                    employee.Projects.Add(project);
                    project.Employees.Add(employee);
                    break;
                case AssignType.Removing:
                    employee.Projects.Remove(project);
                    project.Employees.Remove(employee);
                    break;
            }
           
            await _repositoryManager.SaveAsync();

            return true;
        }

    }
}