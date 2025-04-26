using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProperDiet.Models.Entity;
using ProperDiet.Models.Enums;
using ProperDiet.Services.Calculator;

namespace ProperDiet.Services.Calculator
{
    [TestClass]
    public class CalculatorCaloriesTests
    {
        [TestMethod]
        [DataRow(2700, 3300)] // Expected range for Male with Weight Gain
        public void CalculateCalories_ForMaleWithWeightGain_ShouldReturnCorrectValue(int min, int max)
        {
            // Arrange  
            var human = new Human
            {
                Gender = Gender.Male,
                Weight = 70,
                Height = 175,
                Age = 25,
                Activity = Activity.average,
                CategoryDiet = CategoryDiet.weightGain
            };
            var calculatorCalories = new CalculatorCalories(human);

            // Act  
            var result = calculatorCalories.Calories;

            // Assert  
            Assert.IsTrue(result >= min && result <= max, $"Expected calories to be between {min} and {max}, but got {result}.");
        }

        [TestMethod]
        [DataRow(1400, 1900)] // Expected range for Female with Weight Decay
        public void CalculateCalories_ForFemaleWithWeightDecay_ShouldReturnCorrectValue(int min, int max)
        {
            // Arrange
            var human = new Human
            {
                Gender = Gender.Female,
                Weight = 60,
                Height = 165,
                Age = 30,
                Activity = Activity.low,
                CategoryDiet = CategoryDiet.weightDecay
            };
            var calculatorCalories = new CalculatorCalories(human);

            // Act
            var result = calculatorCalories.Calories;

            // Assert
            Assert.IsTrue(result >= min && result <= max);
        }

        [TestMethod]
        [DataRow(3000, 3500)] // Expected range for Male with Weight Maintain
        public void CalculateCalories_ForMaleWithWeightMaintain_ShouldReturnCorrectValue(int min, int max)
        {
            // Arrange
            var human = new Human
            {
                Gender = Gender.Male,
                Weight = 80,
                Height = 180,
                Age = 40,
                Activity = Activity.high,
                CategoryDiet = CategoryDiet.weightMaintain
            };
            var calculatorCalories = new CalculatorCalories(human);

            // Act
            var result = calculatorCalories.Calories;

            // Assert
            Assert.IsTrue(result >= min && result <= max);
        }

        [TestMethod]
        [DataRow(1300, 1800)] // Expected range for Female with Minimum Activity
        public void CalculateCalories_ForFemaleWithMinimumActivity_ShouldReturnCorrectValue(int min, int max)
        {
            // Arrange
            var human = new Human
            {
                Gender = Gender.Female,
                Weight = 50,
                Height = 160,
                Age = 20,
                Activity = Activity.minimum,
                CategoryDiet = CategoryDiet.weightMaintain
            };
            var calculatorCalories = new CalculatorCalories(human);

            // Act
            var result = calculatorCalories.Calories;

            // Assert
            Assert.IsTrue(result >= min && result <= max);
        }

        [TestMethod]
        [DataRow(4300, 4800)] // Expected range for Male with Very High Activity
        public void CalculateCalories_ForMaleWithVeryHighActivity_ShouldReturnCorrectValue(int min, int max)
        {
            // Arrange
            var human = new Human
            {
                Gender = Gender.Male,
                Weight = 90,
                Height = 190,
                Age = 35,
                Activity = Activity.veryHigh,
                CategoryDiet = CategoryDiet.weightGain
            };
            var calculatorCalories = new CalculatorCalories(human);

            // Act
            var result = calculatorCalories.Calories;

            // Assert
            Assert.IsTrue(result >= min && result <= max);
        }
    }
}
