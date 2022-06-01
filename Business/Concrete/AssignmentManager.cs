using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Results.State;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AssignmentManager : IAssignmentService
    {
        private  IAssignmentDal AssignmentDal {get;}
        public AssignmentManager(IAssignmentDal assignmentDal)
        {
            AssignmentDal = assignmentDal;
        }

        [SecuredOperation("admin,manager")]
        public IResult Add(Assignment assignment)
        {
            AssignmentDal.Add(assignment);
            return new SuccessResult(Messages.SuccessAddOperation);
        }

        [SecuredOperation("admin,manager")]
        public IResult Delete(Assignment assignment)
        {
            AssignmentDal.Delete(assignment);
            return new SuccessResult(Messages.SuccessDeleteOperation);
        }

        public IListDataResult<Assignment> GetAll()
        {
            return new SuccessListDataResult<Assignment>(AssignmentDal.GetAll());
        }

        public ISingleDataResult<Assignment> GetByAssignmentId(int assignmentId)
        {
            return new SuccessSingleDataResult<Assignment>(AssignmentDal.Get(assignment => assignment.Id == assignmentId));
        }

        public IListDataResult<Assignment> GetByUserId(int userId)
        {
            return new SuccessListDataResult<Assignment>(AssignmentDal.GetAll(assignment => assignment.UserId == userId));
        }

        public IListDataResult<AssignmentDto> GetDtoAll()
        {
            return new SuccessListDataResult<AssignmentDto>(AssignmentDal.GetDtoAll());
        }

        public ISingleDataResult<AssignmentDto> GetDtoByAssignmentId(int assignmentId)
        {
            return new SuccessSingleDataResult<AssignmentDto>(AssignmentDal.GetDto(assignment => assignment.AssignmentId == assignmentId));
        }

        public IListDataResult<AssignmentDto> GetDtoByUserId(int userId)
        {
            return new SuccessListDataResult<AssignmentDto>(AssignmentDal.GetDtoAll(assignment => assignment.UserId == userId));
        }

        [SecuredOperation("admin,manager")]
        public IResult Update(Assignment assignment)
        {
            AssignmentDal.Update(assignment);
            return new SuccessResult(Messages.SuccessUpdateOperation);
        }
    }
}
