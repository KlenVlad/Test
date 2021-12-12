using DAL.EF;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories.Abstract
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly VoteContext _context;
        private readonly DbSet<TEntity> _entity;

        public BaseRepository(VoteContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _entity.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            _entity.Remove(item);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _entity.Where(predicate)
                          .ToList();
        }

        public TEntity Get(int id)
        {
            return _entity.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entity.ToList();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
