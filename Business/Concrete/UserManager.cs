using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Results.State;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal UserDal { get; }
        private IUserOperationClaimService UserOperationClaimService { get; }
        public UserManager(IUserDal userDal, IUserOperationClaimService userOperationClaimService)
        {
            UserDal = userDal;
            UserOperationClaimService = userOperationClaimService;
        }

        public IResult Add(User user)
        {
            UserDal.Add(user);
            return new SuccessResult(Messages.SuccessAddOperation);
        }

        [SecuredOperation("admin,manager")]
        public IResult Delete(User user)
        {
            UserDal.Delete(user);
            return new SuccessResult(Messages.SuccessDeleteOperation);
        }

        public ISingleDataResult<User> GetByUserEmail(string email)
        {
            return new SuccessSingleDataResult<User>(UserDal.Get(user => user.Email == email));
        }

        public IListDataResult<User> GetByUserIsApproved(bool isApproved)
        {
            return new SuccessListDataResult<User>(UserDal.GetAll(user => user.IsApproved == isApproved));
        }

        public IListDataResult<UserOperationClaimDto> GetClaims(User user)
        {
            return new SuccessListDataResult<UserOperationClaimDto>(UserOperationClaimService.GetByUserClaims(user).ListData);
        }

        [SecuredOperation("manager,admin")]
        public IListDataResult<User> GetUsers()
        {
            return new SuccessListDataResult<User>(UserDal.GetAll());
        }

        [SecuredOperation("admin,manager")]
        public IResult Update(User user)
        {
            UserDal.Update(user);
            return new SuccessResult(Messages.SuccessUpdateOperation);
        }

        [SecuredOperation("admin")]
        public IListDataResult<User> GetAll()
        {
            return new SuccessListDataResult<User>(UserDal.GetAll());
        }
    }
}
