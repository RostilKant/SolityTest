using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace SolityTest
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(c => c.FullName,
                    options =>
                        options.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();

            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectForCreationDto, Project>();
            CreateMap<ProjectForUpdateDto, Project>();
        }
    }
}