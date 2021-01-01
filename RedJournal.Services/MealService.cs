using RedJournal.Data.Entities;
using RedJournal.Models.Meal;
using RedJournalMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedJournal.Services
{
    public class MealService
    {
        private readonly Guid _userId;
        public MealService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMeal(MealCreate model)
        {
            var entity = new Meal()
            {
                OwnerId = _userId,
                Name = model.Name,
                MoodBefore = model.MoodBefore,
                MoodAfter = model.MoodAfter,
                HungerBefore = model.HungerBefore,
                HungerAfter = model.HungerAfter,
                Location = model.Location,
                WhoWith = model.WhoWith,
                Notes = model.Notes
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Meals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MealListItem> GetMeals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Meals
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new MealListItem
                        {
                            MealId = e.MealId,
                            Name = e.Name,
                            MoodBefore = e.MoodBefore,
                            MoodAfter = e.MoodAfter,
                            HungerBefore = e.HungerBefore,
                            HungerAfter = e.HungerAfter,
                            Location = e.Location,
                            WhoWith = e.WhoWith,
                            Notes = e.Notes
                        });
                return query.ToArray();
            }
        }

    public MealDetail GetMealById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Meals
                    .Single(e => e.MealId == id && e.OwnerId == _userId);
                return
                    new MealDetail
                    {
                        MealId = entity.MealId,
                        Name = entity.Name,
                        MoodBefore = entity.MoodBefore,
                        MoodAfter = entity.MoodAfter,
                        HungerBefore = entity.HungerBefore,
                        HungerAfter = entity.HungerAfter,
                        Location = entity.Location,
                        WhoWith = entity.WhoWith,
                        Notes = entity.Notes
                    };
            }
        }

        public bool UpdateMeal(MealEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Meals
                    .Single(e => e.MealId == model.MealId && e.OwnerId == _userId);


                entity.Name = model.Name;
                entity.MoodBefore = model.MoodBefore;
                entity.MoodAfter = model.MoodAfter;
                entity.HungerBefore = model.HungerBefore;
                entity.HungerAfter = model.HungerAfter;
                entity.Location = model.Location;
                entity.WhoWith = model.WhoWith;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMeal(int mealId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Meals
                    .Single(e => e.MealId == mealId && e.OwnerId == _userId);
                
                ctx.Meals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
