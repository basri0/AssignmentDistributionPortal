using Core.Entities.Concrete;
using Core.Utilities.Security.JWT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT.Abstract
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
