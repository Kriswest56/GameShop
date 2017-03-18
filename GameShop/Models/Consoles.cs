using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameShop.Models
{
    public class Consoles
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(30)]
        [Required]
        public string Name { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

    }
}
