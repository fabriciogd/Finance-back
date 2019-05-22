using AutoMapper;
using Finance.Core.Base;
using Finance.Core.Contract;
using Finance.EF.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance.Core.Implementation
{
    public class RepositoryQuery<TEntity, TDTO> : IRepositoryQuery<TEntity, TDTO>
        where TEntity : Poco
        where TDTO : Dto
    {
        private readonly IDatabaseContext _context;

        public RepositoryQuery(IDatabaseContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> Queryable
        {
            get
            {
                return this._context.AsNoTracking<TEntity>();
            }
        }

        public TDTO Get(int id)
        {
            var row = this.Queryable.FirstOrDefault(a => a.Id == id);

            return Mapper.Map<TDTO>(row);
        }

        public IEnumerable<TDTO> GetAll()
        {
            var query = this.Queryable;

            var rows = query.ToList();

            return Mapper.Map<IList<TDTO>>(rows);
        }
    }
}
