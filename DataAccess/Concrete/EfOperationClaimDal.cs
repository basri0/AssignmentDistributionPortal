using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, AssignmentDistributionDbContext>,IOperationClaimDal
    {
    }
}
