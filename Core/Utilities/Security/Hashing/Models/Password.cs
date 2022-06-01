using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing.Models
{
    public class Password : IModel
    {
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
