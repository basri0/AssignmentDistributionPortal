using Core.Entities.Concrete;
using Entities.Dtos;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);

        IListDataResult<UserOperationClaim> GetUserOperationClaims();
        IListDataResult<UserOperationClaimDto> GetByUserClaims(User user);

        IListDataResult<UserOperationClaimDto> GetAll();
        IListDataResult<UserOperationClaimDto> GetByUserId(int userId);
        IListDataResult<UserOperationClaimDto> GetByUserEmail(string userEmail);
    }
}
