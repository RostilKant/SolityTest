using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public ProjectService(IRepositoryManager repositoryManager, ILogger<ProjectService> logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public async Task<IEnumerable<Project>> GetManyAsync()
        {
            try
            {
                return await _repositoryManager.Project.GetAllProjectsAsync(false);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Something went wrong");
                return null;
            }
        }

        public Task<Project> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}