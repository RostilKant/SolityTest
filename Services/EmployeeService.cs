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
    }
}