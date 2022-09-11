﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NorthBook.DataAccess.Data;
using NorthBook.DataAccess.Repository.IRepository;

namespace NorthBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> DbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            //_db.ShoppingCarts.Include(u => u.Product).Include(u=>u.CoverType);
            this.DbSet = _db.Set<T>();
        }
        public void Add(T? entity)
        {
            DbSet.Add(entity!);
        }
        //includeProp - "Category,CoverType"
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter!);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList()!;
        }

        public T? GetFirstOrDefault(Expression<Func<T?, bool>> filter, string? includeProperties = null, bool tracked = true)
        {
            if (tracked)
            {
                IQueryable<T> query = DbSet;

                query = query.Where(filter)!;
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.FirstOrDefault();
            }
            else
            {
                IQueryable<T> query = DbSet.AsNoTracking();

                query = query.Where(filter)!;
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp)!;
                    }
                }
                return query.FirstOrDefault();
            }

        }

        public void Remove(T? entity)
        {
            DbSet.Remove(entity!);
        }

        public void RemoveRange(IEnumerable<T?> entity)
        {
            DbSet.RemoveRange(entity!);
        }
    }
}