using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class AssignmentDto : IDto
    {

        public int AssignmentId { get; set; }
        public int UserId { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
