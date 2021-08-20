using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ShareApi.Models
{
    public class Share
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string StockName { get; set; }
        [Required]
        public double BuyPrice { get; set; }

        public string Discription { get; set; }

        public User User { get; set; }


        #region Constructors
        public Share()
        {

        }

        public Share(string name, string stockName, int buyPrice) : this()
        {
            Name = name;
            StockName = stockName;
            BuyPrice = buyPrice;
            
        }



        #endregion
    }
}
