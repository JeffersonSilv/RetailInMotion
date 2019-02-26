using RetailInMotion.Domain.Abstract;
using System;
using System.Collections.Generic;

namespace RetailInMotion.Data.Abstract
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        TEntity GetById(Guid id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(Guid id);

        IEnumerable<TEntity> GetPaged(int page, int pageSize);
    }
}

