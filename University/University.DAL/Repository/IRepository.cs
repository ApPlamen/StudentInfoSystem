﻿namespace University.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class, new()
    {
        IQueryable<T> All(params Expression<Func<T, object>>[] includeExpressions);

        IQueryable<T> All(bool includeInactive, params Expression<Func<T, object>>[] includeExpressions);

        IQueryable<T> GetAll();

        T GetById(object id);

        bool Exists(T entity);

        T Add(T entity);

        T Save(T entity);

        void Save();

        void Delete(object id);
    }
}
