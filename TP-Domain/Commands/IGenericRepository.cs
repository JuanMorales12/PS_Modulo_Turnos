using System;
using System.Collections.Generic;
using TP_Domain.Entities;

namespace TP_Domain.Commands
{
    public interface IGenericRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete(Guid id);
    }
}