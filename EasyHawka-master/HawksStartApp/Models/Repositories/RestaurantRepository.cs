using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HawksStartApp.Models.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>
    {
        public RestaurantRepository(HawkaContext hawkaContext) : base(hawkaContext)
        {

        }
    }
}