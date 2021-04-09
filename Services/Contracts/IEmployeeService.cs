using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Services.Contracts
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<EmployeeDto>> GetManyAsync();
        public Task<EmployeeDto> GetByIdAsync(Guid id);
        public Task<EmployeeDto> CreateAsync(EmployeeForCreationDto employeeForCreation);
        public Task<bool> DeleteAsync(Guid id);
        public Task<bool> UpdateAsync(Guid id, EmployeeForUpdateDto employeeForUpdate);

    }
}