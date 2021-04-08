using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace SolityTest.Controllers
{
    [Route("api/employees/{employeeId}/projects")]
    [ApiController]
    public class EmployeesProjects : ControllerBase
    {
        private readonly IProjectService _projectService;

        public EmployeesProjects(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetEmployeeProjects(Guid employeeId) =>
            Ok(await _projectService.GetManyAsync(employeeId));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeProject(Guid employeeId, Guid id)
        {
            var project = await _projectService.GetByIdAsync(employeeId, id);
            return project == null ? NotFound() : Ok(project);
        }
    }
}