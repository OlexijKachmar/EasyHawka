using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HawksStartApp.Models
{
    public class Restaurant
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name{ get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public string Specialization { get; set; }

        [Required]
        public bool IsWifi { get; set; }

        [Required]
        public bool AreSittingPlaces { get; set; }

        public string Address { get; set; }

        public byte[] Image { get; set; }
        
        public ICollection<RestaurantCorpuse> RestaurantCorpuses { get; set; }
    }
}