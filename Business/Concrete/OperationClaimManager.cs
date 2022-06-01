using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Results.State;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    [SecuredOperation("admin")]
    public class OperationClaimManager : IOperationClaimService
    {
        private IOperationClaimDal OperationClaimDal { get; }
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            OperationClaimDal = operationClaimDal;
        }

        public IListDataResult<OperationClaim> GetOperationClaims()
        {
            return new SuccessListDataResult<OperationClaim>(OperationClaimDal.GetAll());
        }

        public ISingleDataResult<OperationClaim> GetByOperationClaimId(int operationClaimId)
        {
            return new SuccessSingleDataResult<OperationClaim>(OperationClaimDal.Get(operationClaim => operationClaim.Id == operationClaimId));
        }

        public IResult Add(OperationClaim operationClaim)
        {
            OperationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.SuccessAddOperation);
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            OperationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.SuccessDeleteOperation);
        }

        public IResult Update(OperationClaim operationClaim)
        {
            OperationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.SuccessUpdateOperation);
        }
    }
}
