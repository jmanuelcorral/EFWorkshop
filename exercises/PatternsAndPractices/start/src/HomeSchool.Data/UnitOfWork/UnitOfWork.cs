using System.Threading.Tasks;

namespace HomeSchool.Data.UnitOfWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext Context;
        public UnitOfWork(DataContext context)
        {
            Context = context;
        }
        public bool SaveChanges()
        {
            int recordsAffected = Context.SaveChanges();
            return (recordsAffected > 0);
        }

        public async Task<bool> SaveChangesAsync()
        {
            int recordsAffected = await Context.SaveChangesAsync();
            return (recordsAffected > 0);
        }
    }
}
