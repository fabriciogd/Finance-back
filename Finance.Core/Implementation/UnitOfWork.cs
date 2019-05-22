using Finance.Core.Contract;
using Finance.EF.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finance.Core.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _context;

        public UnitOfWork(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.SaveChangesAsync();
        }
    }
}
