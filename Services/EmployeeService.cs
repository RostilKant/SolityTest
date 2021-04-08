using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public EmployeeService(IRepositoryManager repositoryManager, ILogger<EmployeeService> logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }


        public async Task<IEnumerable<Employee>> GetManyAsync()
        {
            try
            {
                _logger.LogInformation("Entering try scope");
                return await _repositoryManager.Employee.GetAllEmployees(false);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something goes wrong");
                return null;
            }
        }

        public Task<Employee> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}