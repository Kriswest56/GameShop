using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class UserReview
    {

        public int ID { get; set; }

        [StringLength(30)]
        [Required]
        public string name { get; set; }

        [StringLength(30)]
        [Required]
        public string game { get; set; }

        [StringLength(30)]
        [Required]
        public string rating { get; set; }

        public string review { get; set; }

    }
}
