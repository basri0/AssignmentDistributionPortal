using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsApproved { get; set; }
    }
}
