using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HawksStartApp.Models
{
    public class RestaurantCorpuse
    {

        public int CorpuseId { get; set; }
        public Corpuse Corpuse { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}


