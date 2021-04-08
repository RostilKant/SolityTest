using System;

namespace Entities.DataTransferObjects
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime StartDate { get; set; }
     
        public DateTime ReleaseDate { get; set; }
    }
}