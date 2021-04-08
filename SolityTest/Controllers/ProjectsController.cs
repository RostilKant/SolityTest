using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace SolityTest.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpGet("projects")]
        public async Task<IActionResult> GetProjects() =>
            Ok(await _projectService.GetManyAsync(Guid.Empty));
        
        [HttpGet("projects/{id}")]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var project = await _projectService.GetByIdAsync(Guid.Empty, id);
            return project == null ? NotFound() : Ok(project);
        }
        
    }
}