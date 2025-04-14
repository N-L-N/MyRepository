using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDiet.Models.Entity
{
    public class MealEntry
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FoodId { get; set; }

        public int PortionSize { get; set; } 
           
        public DateTime Date { get; set; }
    }
}
