using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HawksStartApp.Models.ViewModel
{
    public class HawkaFilters
    {
        public string Price { get; set; }

        public string Specialization { get; set; }

        public bool IsWIfi { get; set; }

        public bool AreSittingPlaces { get; set; }

        public int CorpusNumber { get; set; }
    }
}