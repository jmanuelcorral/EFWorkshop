using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeSchool.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}
