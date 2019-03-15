using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HawksStartApp.Models
{
    public class Corpuse
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 100)]
        [Required]
        public int Number { get; set; }

        public ICollection<RestaurantCorpuse> RestaurantCorpuses { get; set; }
    }

}