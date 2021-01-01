using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedJournal.Models.Food
{
    public class FoodDetail
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public int Calories { get; set; }
    }
}
