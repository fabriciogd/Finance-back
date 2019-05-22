using Finance.Core.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finance.Core.Contract
{
    public interface IRepositoryQuery<TEntity, TDTO>
        where TEntity : Poco
        where TDTO : Dto
    {
        IEnumerable<TDTO> GetAll();

        TDTO Get(int id);
    }
}
