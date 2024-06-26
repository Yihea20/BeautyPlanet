﻿using BeautyPlanet.DataAccess;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using BeautyPlanet.IRepository;
using X.PagedList;
using BeautyPlanet.Models.Entity;

namespace BeautyPlanet.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BeautyDbContext _context;
        private readonly DbSet<T> _db;
        public GenericRepository(BeautyDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
            , Func<IQueryable<T>, IIncludableQueryable<T, object>> includee = null)
        {
            IQueryable<T> query = _db;
            if (include != null)
            {
                query = include(query);
            }

            if (includee != null)
            {
                query = includee(query);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includee = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (includee != null)
            {
                query = includee(query);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IPagedList<T>> GetPagingAll(
         Expression<Func<T, bool>> expression = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,RequestParams request=null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToPagedListAsync(request.PageNumber, request.PageSize);
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);

        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}
