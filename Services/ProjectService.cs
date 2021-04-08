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
    public class ProjectService : IProjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<ProjectService> _logger;
        private readonly IMapper _mapper;

        public ProjectService(IRepositoryManager repositoryManager, ILogger<ProjectService> logger, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDto>> GetManyAsync()
        {
            var projects = await _repositoryManager.Project.GetAllProjectsAsync(false);
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public Task<Project> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}