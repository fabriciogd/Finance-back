using Finance.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finance.Core.Contract
{
    public interface IRepository<TEntity> where TEntity : Poco
    {
        Task<TEntity> Get(int id, CancellationToken ct = default(CancellationToken));

        Task<TEntity> Add(TEntity entity, CancellationToken ct = default(CancellationToken));

        Task<TEntity> Update(TEntity entity, CancellationToken ct = default(CancellationToken));

        void Delete(TEntity entity);
    }
}
