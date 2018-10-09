using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineAndDine.BL.Models;

namespace WineAndDine.BL.ContractInterfaces.DbContracts
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        //List<Restaurant> GetAll(int pageIndex, int pageSize, out int totalCount);

        List<Restaurant> GetAll();
    }
}
