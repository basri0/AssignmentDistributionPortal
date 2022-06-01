using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfAssignmentDal : EfEntityRepositoryBase<Assignment, AssignmentDistributionDbContext>, IAssignmentDal
    {
        public AssignmentDto GetDto(Expression<Func<AssignmentDto, bool>> filter)
        {
            using (var context = new AssignmentDistributionDbContext())
            {
                var result = from assignment in context.Assignments
                             join user in context.Users on assignment.UserId equals user.Id
                             select new AssignmentDto()
                             {
                                 AssignmentId = assignment.Id,
                                 UserId = user.Id,
                                 Name = assignment.Name,
                                 Description = assignment.Description,

                                 UserEmail = user.Email,
                                 UserFirstName = user.FirstName,
                                 UserLastName = user.LastName
                             };
                return result.SingleOrDefault();
            }
        }

        public List<AssignmentDto> GetDtoAll(Expression<Func<AssignmentDto, bool>> filter = null)
        {
            using (var context = new AssignmentDistributionDbContext())
            {
                var result = from assignment in context.Assignments
                             join user in context.Users on assignment.UserId equals user.Id
                             select new AssignmentDto()
                             {
                                 AssignmentId = assignment.Id,
                                 UserId = user.Id,
                                 Name = assignment.Name,
                                 Description = assignment.Description,

                                 UserEmail = user.Email,
                                 UserFirstName = user.FirstName,
                                 UserLastName = user.LastName
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
