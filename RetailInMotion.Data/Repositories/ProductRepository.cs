using Microsoft.EntityFrameworkCore;
using RetailInMotion.Data.Concrete;
using RetailInMotion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using RetailInMotion.Data.Abstract;

namespace RetailInMotion.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        public Product GetById(Guid id)
        {
            return _context.Set<Product>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public void Create(Product entity)
        {
            _context.Set<Product>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Product entity)
        {
            _context.Set<Product>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.Set<Product>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetPaged(int page, int pageSize)
        {
            var results = _context.Set<Product>().AsQueryable();

            var paged = new Paged<Product>(results);
            return paged.GetRange(page, pageSize);
        }
    }
}
