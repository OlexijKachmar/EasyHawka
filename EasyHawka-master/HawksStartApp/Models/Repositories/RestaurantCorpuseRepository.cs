using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HawksStartApp.Models.Repositories
{
    public class RestaurantCorpuseRepository: BaseRepository<RestaurantCorpuse>
    {
        public RestaurantCorpuseRepository(HawkaContext hawkaContext) : base(hawkaContext)
        {
        }
    }
}