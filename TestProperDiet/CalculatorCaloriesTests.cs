

using ProperDiet.Models.Entity;
using ProperDiet.Models.Enums;
using ProperDiet.Services.Calculator;

namespace TestProperDiet
{
    public class CalculatorCaloriesTests
    {
        [Fact]
        public void CalculateCalories_ForMale_MinimumActivity_MaintainWeight()
        {
            // Arrange
            var human = new Human
            {
                Gender = Gender.Male,
                Weight = 80,
                Height = 180,
                Age = 25,
                Activity = Activity.minimum,
                CategoryDiet = CategoryDiet.weightMaintain
            };

            // Act
            var calculator = new CalculatorCalories(human);

            // Assert
            double expectedBMR = 66.5 + (13.75 * 80) + (5.003 * 180) - (6.755 * 25);
            double expectedCalories = expectedBMR * 1.2; // minimum activity
            Assert.InRange(calculator.Calories, (int)expectedCalories - 1, (int)expectedCalories + 1);
        }

        [Fact]
        public void CalculateCalories_ForFemale_AverageActivity_WeightDecay()
        {
            // Arrange
            var human = new Human
            {
                Gender = Gender.Female,
                Weight = 60,
                Height = 165,
                Age = 30,
                Activity = Activity.average,
                CategoryDiet = CategoryDiet.weightDecay
            };

            // Act
            var calculator = new CalculatorCalories(human);

            // Assert
            double expectedBMR = 655.1 + (9.563 * 60) + (1.85 * 165) - (4.676 * 30);
            double expectedCalories = expectedBMR * 1.55 * 0.8;
            Assert.InRange(calculator.Calories, (int)expectedCalories - 1, (int)expectedCalories + 1);
        }

        [Fact]
        public void CalculateCalories_ForMale_HighActivity_WeightGain()
        {
            // Arrange
            var human = new Human
            {
                Gender = Gender.Male,
                Weight = 90,
                Height = 185,
                Age = 28,
                Activity = Activity.high,
                CategoryDiet = CategoryDiet.weightGain
            };

            // Act
            var calculator = new CalculatorCalories(human);

            // Assert
            double expectedBMR = 66.5 + (13.75 * 90) + (5.003 * 185) - (6.755 * 28);
            double expectedCalories = expectedBMR * 1.725 * 1.2;
            Assert.InRange(calculator.Calories, (int)expectedCalories - 1, (int)expectedCalories + 1);
        }

        [Fact]
        public void CalculateCalories_WhenZeroValues_ReturnsMinimum()
        {
            // Arrange
            var human = new Human
            {
                Gender = Gender.Male,
                Weight = 0,
                Height = 0,
                Age = 0,
                Activity = Activity.minimum,
                CategoryDiet = CategoryDiet.weightMaintain
            };

            // Act
            var calculator = new CalculatorCalories(human);

            // Assert
            double expectedCalories = (66.5 + 0 + 0 - 0) * 1.2;
            Assert.Equal((int)expectedCalories, calculator.Calories);
        }
    }
}


