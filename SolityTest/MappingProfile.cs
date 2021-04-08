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

            CreateMap<Project, ProjectDto>();
        }
    }
}