using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedJournal.Data.Entities
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public int Calories { get; set; }
    }
}
