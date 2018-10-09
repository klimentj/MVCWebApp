using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineAndDine.BL.ContractInterfaces.DbContracts
{
    public interface IRepository<T>
    {
        void Insert(T entity);

        void Delete(int id);

        void Delete(T entity);

        //IQueryable<T> GetAll(T);
    }
}
