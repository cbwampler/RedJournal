using RedJournal.Data.Entities;
using RedJournal.Models.Food;
using RedJournalMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedJournal.Services
{
    public class FoodService
    {
        private readonly Guid _userId;
        public FoodService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFood(FoodCreate model)
        {
            var entity = new Food()
            {
                OwnerId = _userId,
                Name = model.Name,
                Amount = model.Amount,
                Calories = model.Calories
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Foods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FoodListItem> GetFoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Foods
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new FoodListItem
                        {
                            FoodId = e.FoodId,
                            Name = e.Name,
                            Amount = e.Amount,
                            Calories = e.Calories
                        });
                return query.ToArray();
            }
        }

        public FoodDetail GetFoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Foods
                    .Single(e => e.FoodId == id && e.OwnerId == _userId);
                return
                    new FoodDetail
                    {
                        FoodId = entity.FoodId,
                        Name = entity.Name,
                        Amount = entity.Amount,
                        Calories = entity.Calories
                    };
            }
        }

        public bool UpdateFood(FoodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Foods
                    .Single(e => e.FoodId == model.FoodId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Amount = model.Amount;
                entity.Calories = model.Calories;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFood(int foodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Foods
                    .Single(e => e.FoodId == foodId && e.OwnerId == _userId);

                ctx.Foods.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
