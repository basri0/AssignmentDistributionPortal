using Core.Entities.Concrete;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IListDataResult<OperationClaim> GetOperationClaims();        
        ISingleDataResult<OperationClaim> GetByOperationClaimId(int operationClaimId);
       
        IResult Add(OperationClaim operationClaim);        
        IResult Delete(OperationClaim operationClaim);       
        IResult Update(OperationClaim operationClaim);
    }
}
