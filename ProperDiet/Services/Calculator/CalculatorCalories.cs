using ProperDiet.Models.Entity;
using ProperDiet.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDiet.Services.Calculator
{
    public class CalculatorCalories
    {
        public int Calories { get; private set; }

        public CalculatorCalories(Human human)
        {
            // Расчет BMR (базового обмена веществ)
            double bmr;
            if (human.Gender == Gender.Female)
            {
                bmr = 655.1 + (9.563 * human.Weight) + (1.85 * human.Height) - (4.676 * human.Age);
            }
            else
            {
                bmr = 66.5 + (13.75 * human.Weight) + (5.003 * human.Height) - (6.755 * human.Age);
            }

            // Учет уровня физической активности
            double activityMultiplier = 1.0;
            if (human.Activity == Activity.minimum)
            {
                activityMultiplier = 1.2;
            }
            else if (human.Activity == Activity.low)
            {
                activityMultiplier = 1.375;
            }
            else if (human.Activity == Activity.average)
            {
                activityMultiplier = 1.55;
            }
            else if (human.Activity == Activity.high)
            {
                activityMultiplier = 1.725;
            }
            else if (human.Activity == Activity.veryHigh)
            {
                activityMultiplier = 1.9;
            }

            // Расчет общей калорийности с учетом активности
            double totalCalories = bmr * activityMultiplier;

            // Корректировка по категории диеты
            if (human.CategoryDiet == CategoryDiet.weightGain)
            {
                Calories = (int)(totalCalories * 1.20); // Набор веса
            }
            else if (human.CategoryDiet == CategoryDiet.weightDecay)
            {
                Calories = (int)(totalCalories * 0.8); // Снижение веса
            }
            else
            {
                Calories = (int)totalCalories; // Поддержание веса
            }
        }
    }


}
