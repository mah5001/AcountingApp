﻿using Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private AcountingDB _db;
        private DbSet<TEntity> _dbset;

        public GenericRepository(AcountingDB db)
        {
            _db = db;
            _dbset = _db.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbset.Add(entity);
        }

        public virtual TEntity GetById(object Id)
        {
            return _dbset.Find(Id);
        }

        public virtual void Update(TEntity entity)
        {
            _dbset.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _dbset.Attach(entity);
            }

            _dbset.Remove(entity);
        }

        public virtual void Delete(object Id)
        {
            var entity = GetById(Id);
            Delete(entity);

        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = _dbset;
            if (where != null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }
    }
}
