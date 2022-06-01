using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimDto> GetDtoUserOperationClaims(User user);

        List<UserOperationClaimDto> GetDtoAll(Expression<Func<UserOperationClaimDto,bool>> filter = null);
        UserOperationClaimDto GetDtoSingle(Expression<Func<UserOperationClaimDto, bool>> filter);
    }
}
