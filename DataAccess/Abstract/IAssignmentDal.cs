using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IAssignmentDal : IEntityRepository<Assignment>
    {
        List<AssignmentDto> GetDtoAll(Expression<Func<AssignmentDto,bool> > filter = null);
        AssignmentDto GetDto(Expression<Func<AssignmentDto, bool>> filter);
    }
}
