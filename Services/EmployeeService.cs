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

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            var employee = await _repositoryManager.Employee.GetEmployeeAsync(id, false);
            return _mapper.Map<Employee>(employee);
        }
    }
}