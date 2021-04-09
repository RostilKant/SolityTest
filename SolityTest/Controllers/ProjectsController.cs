using System;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace SolityTest.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProjects() =>
            Ok(await _projectService.GetManyAsync(Guid.Empty));
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProject(Guid id)
        {
            var project = await _projectService.GetByIdAsync(Guid.Empty, id);
            return project == null ? NotFound() : Ok(project);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] ProjectForCreationDto projectForCreation)
        {
            if (projectForCreation == null)
                return BadRequest("ProjectForCreationDto is null");
            
            var projectDto = await _projectService.CreateAsync(projectForCreation);
            return CreatedAtAction("GetProject", new {id = projectDto.Id}, projectDto);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var project = await _projectService.DeleteAsync(id);
            return project ? NoContent() : NotFound();
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProject(Guid id, [FromBody] ProjectForUpdateDto projectForUpdate)
        {
            var project = await _projectService.UpdateAsync(id, projectForUpdate);
            return project ? NoContent() : NotFound();
        }
        
        [HttpGet("{id:guid}/daysLeft")]
        public async Task<IActionResult> GetDaysLeftToRelease(Guid id)
        {
            var project = await _projectService.GetDaysLeftToReleaseAsync(id);
            return project == 0 ? NotFound() : Ok(project);
        }

    }
}