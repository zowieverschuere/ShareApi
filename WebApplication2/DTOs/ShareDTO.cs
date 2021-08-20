using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShareApi.DTOs
{
    public class ShareDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string StockName { get; set; }
        [Required]
        public double BuyPrice { get; set; }

        public string Discription { get; set; }


    }
}
