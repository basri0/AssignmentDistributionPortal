using Core.Entities.Concrete;
using Core.Utilities.Security.JWT.Models;
using Entities.Dtos;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthenticationService
    {
        IDataResult<AuthenticatedDto> Login(UserForLoginDto userForLoginDto);
        IDataResult<AuthenticatedDto> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<AccessToken> CreateAccessToken(User user);

    }
}
