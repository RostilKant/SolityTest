using System;

namespace Entities.DataTransferObjects
{
    public class ProjectForCreationDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}