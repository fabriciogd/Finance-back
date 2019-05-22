using Finance.EF.Base;
using Finance.EF.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finance.EF.Implementation
{
    public class DatabaseContext : ContextBase, IDatabaseContext, IDisposable
    {
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        public override async Task<int> SaveChangesAsync(CancellationToken ct = default(CancellationToken))
        {
            try
            {
                return await base.SaveChangesAsync(ct);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public IQueryable<TEntity> AsNoTracking<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>().AsNoTracking();
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
