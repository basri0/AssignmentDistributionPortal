using Core.Entities.Concrete;
using Entities.Dtos;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);
        ISingleDataResult<User> GetByUserEmail(string email);
        IListDataResult<UserOperationClaimDto> GetClaims(User user);
        IListDataResult<User> GetUsers();
        IListDataResult<User> GetByUserIsApproved(bool isApproved);

        IListDataResult<User> GetAll();
    }
}
