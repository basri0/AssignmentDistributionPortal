using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT.Models
{
    public class AccessToken : IModel
    {

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
