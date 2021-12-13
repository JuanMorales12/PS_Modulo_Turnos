using System;
using System.Collections.Generic;
using System.Text;
using TP_Domain.Commands;

namespace TP_AccessData.Commands
{
    public class GenericsRepository:IGenericRepository
    {
        private readonly TemplateDbContext _context;
        public GenericsRepository(TemplateDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
