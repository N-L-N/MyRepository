using ProperDiet.Models.Enums;

namespace ProperDiet.Models.Entity
{
    public class Human
    {
        public int Id { get; set; }

        public double Height { get; set; }

        public int Age { get; set; }

        public double Weight { get; set; }

        public CategoryDiet CategoryDiet { get; set; }

        public Gender Gender { get; set; }

        public Activity Activity { get; set; }
    }
}
