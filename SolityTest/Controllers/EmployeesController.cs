using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace SolityTest.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees() =>
            Ok(await _employeeService.GetManyAsync());
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            return employee == null ? NotFound() : Ok(employee);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeForCreationDto employeeForCreation)
        {
            if (employeeForCreation == null)
                return BadRequest("EmployeeForCreationDto is null");
            
            var employeeDto = await _employeeService.CreateAsync(employeeForCreation);
            return CreatedAtAction("GetEmployee", new {id = employeeDto.Id}, employeeDto);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var employee = await _employeeService.DeleteAsync(id);
            return employee ? NoContent() : NotFound();
        }
         
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeForUpdateDto employeeForUpdate)
        {
            var employee = await _employeeService.UpdateAsync(id, employeeForUpdate);
            return employee ? NoContent() : NotFound();
        }
    }
}