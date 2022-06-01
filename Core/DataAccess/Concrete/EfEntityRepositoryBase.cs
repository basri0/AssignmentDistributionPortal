using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TDataBase> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TDataBase : DbContext, new()
    {

        //public TDataBase DataBase => new TDataBase();


        public void Add(TEntity entity)
        {
            using (TDataBase context = new TDataBase())
            {
                var entityAdd = context.Entry(entity);
                entityAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TDataBase context = new TDataBase())
            {
                var entityDelete = context.Entry(entity);
                entityDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TDataBase context = new TDataBase())
            {
                return context.Set<TEntity>().Where(filter).SingleOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TDataBase context = new TDataBase())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TDataBase context = new TDataBase())
            {
                return await (filter == null ? context.Set<TEntity>().ToListAsync() : context.Set<TEntity>().Where(filter).ToListAsync());
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TDataBase context = new TDataBase())
            {
                return await (context.Set<TEntity>().Where(filter).SingleOrDefaultAsync());
            }
        }

        public void Update(TEntity entity)
        {
            using (TDataBase context = new TDataBase())
            {
                var entityUpdate = context.Entry(entity);
                entityUpdate.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
