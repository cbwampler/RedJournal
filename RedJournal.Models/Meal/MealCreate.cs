﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedJournal.Models.Meal
{
    public class MealCreate
    {
        public string Name { get; set; }
        public string MoodBefore { get; set; }
        public string MoodAfter { get; set; }
        public string HungerBefore { get; set; }
        public string HungerAfter { get; set; }
        public string Location { get; set; }
        public string WhoWith { get; set; }
        public string Notes { get; set; }
    }
}
