using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.Models;

namespace WineAndDine.BL.ContractInterfaces.DbContracts
{
    public interface IMenuRepository : IRepository<Menu>
    {
        ///// <summary>
        ///// Return paged result of all menus
        ///// </summary>
        ///// <returns></returns>
        //List<Menu> GetAll(int pageIndex, int pageSize, out int totalCount);

        /// <summary>
        /// Return all menus
        /// </summary>
        /// <returns></returns>
        List<Menu> GetAll();
    }
}
