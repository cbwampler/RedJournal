using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedJournal.Data.Entities
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public string MoodBefore { get; set; }
        public string MoodAfter { get; set; }
        public string HungerBefore { get; set; }
        public string HungerAfter { get; set; }
        public string Location { get; set; }
        public string WhoWith { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset DateEntered { get; set; }
    }
}
