using System;
using Entities.Enums;

namespace Entities.DataTransferObjects
{
    public class ProjectAssignManipulationDto
    {
        public Guid Id { get; set; }
        
        public AssignType AssignType { get; set; }
    }
}