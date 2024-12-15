using ProperDiet.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDiet.Services.Comparers
{
    public class MealEntryComparer : IEqualityComparer<MealEntry>
    {
        public bool Equals(MealEntry x, MealEntry y)
        {
            if (x == null || y == null) return false;
            return x.Id == y.Id && x.FoodId == y.FoodId && x.Date == y.Date && x.UserId == y.UserId;
        }

        public int GetHashCode(MealEntry obj)
        {
            return HashCode.Combine(obj.Id, obj.FoodId, obj.Date, obj.UserId);
        }
    }
}
