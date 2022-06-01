using Entities.Concrete;
using Entities.Dtos;
using ResultsNetStandard.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAssignmentService
    {
        IResult Add(Assignment assignment);
        IResult Delete(Assignment assignment);
        IResult Update(Assignment assignment);


        IListDataResult<Assignment> GetAll();
        ISingleDataResult<Assignment> GetByAssignmentId(int assignmentId);
        IListDataResult<Assignment> GetByUserId(int userId);

        IListDataResult<AssignmentDto> GetDtoAll();
        ISingleDataResult<AssignmentDto> GetDtoByAssignmentId(int assignmentId);
        IListDataResult<AssignmentDto> GetDtoByUserId(int userId);

    }
}
