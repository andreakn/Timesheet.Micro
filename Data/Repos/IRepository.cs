using System.Collections.Generic;
using Timesheet.Micro.Models.Domain.Model;

namespace Timesheet.Micro.Data.Repos
{
    public interface IRepository<T> where T : PersistentObject
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Save(T entity);
        void Delete(T entity);
    }
}
