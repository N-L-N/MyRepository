using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProperDiet.Entity;
using ProperDiet.Models.Entity;
using ProperDiet.Services.Data;
using System;
using System.IO;

namespace ProperDiet.Services.Data
{
    [TestClass]
    public class TxtDbContextTests
    {
        private const string TestFilePath = "test_data.txt";

        [TestInitialize]
        public void Setup()
        {
            // Создаем тестовый файл с данными
            File.WriteAllLines(TestFilePath, new[]
            {
                "# Категории",
                "1;Фрукты;Полезные фрукты",
                "2;Овощи;Полезные овощи",
                "# Еда",
                "1;Яблоко;Сладкое яблоко;52;1",
                "2;Морковь;Свежая морковь;41;2",
                "# Пользователи",
                "1;user1;password1;1",
                "# Телосложение",
                "1;180;25;75;weightMaintain;Male;average",
                "# Прием пищи",
                "1;1;2023-10-01;1;150"
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Удаляем тестовый файл после выполнения тестов
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }

        [TestMethod]
        public void AddCategory_ShouldAddCategoryToFile()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);
            var newCategory = new Category { Id = 3, Name = "Мясо", Description = "Белковая пища" };

            // Act
            txtDbContext.AddCategory(newCategory);

            // Assert
            var categories = txtDbContext.GetCategories();
            Assert.AreEqual(3, categories.Count);
            Assert.AreEqual("Мясо", categories[2].Name);
        }

        [TestMethod]
        public void AddFood_ShouldAddFoodToFile()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);
            var newFood = new Food { Id = 3, Name = "Груша", Description = "Сочная груша", Calories = 57, CategoryId = 1 };

            // Act
            txtDbContext.AddFood(newFood);

            // Debug: Получаем содержимое файла для проверки
            var fileContent = File.ReadAllText(TestFilePath);

            // Assert
            var foods = txtDbContext.GetFoods();
            Assert.AreEqual(3, foods.Count);
            Assert.AreEqual("Груша", foods[2].Name);
        }

        [TestMethod]
        public void GetCategories_ShouldReturnAllCategories()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);

            // Act
            var categories = txtDbContext.GetCategories();

            // Assert
            Assert.AreEqual(2, categories.Count);
            Assert.AreEqual("Фрукты", categories[0].Name);
        }

        [TestMethod]
        public void GetFoods_ShouldReturnAllFoods()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);

            // Act
            var foods = txtDbContext.GetFoods();

            // Assert
            Assert.AreEqual(2, foods.Count);
            Assert.AreEqual("Яблоко", foods[0].Name);
        }

        [TestMethod]
        public void GetFoodsByCategory_ShouldReturnFoodsForCategory()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);

            // Act
            var foods = txtDbContext.GetFoodsByCategory(1);

            // Assert
            Assert.AreEqual(1, foods.Count);
            Assert.AreEqual("Яблоко", foods[0].Name);
        }

        [TestMethod]
        public void GetLastCategoryId_ShouldReturnLastCategoryId()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);

            // Act
            var lastCategoryId = txtDbContext.GetLastCategoryId();

            // Assert
            Assert.AreEqual(2, lastCategoryId);
        }

        [TestMethod]
        public void GetLastFoodId_ShouldReturnLastFoodId()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);

            // Act
            var lastFoodId = txtDbContext.GetLastFoodId();

            // Assert
            Assert.AreEqual(2, lastFoodId);
        }

        [TestMethod]
        public void GetFoodById_ShouldReturnCorrectFood()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);

            // Act
            var food = txtDbContext.GetFoodById(1);

            // Assert
            Assert.IsNotNull(food);
            Assert.AreEqual("Яблоко", food.Name);
        }

        [TestMethod]
        public void AddUser_ShouldAddUserToFile()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);
            var newUser = new User { Id = 2, Name = "user2", Password = "password2", HumanId = 1 };

            // Act
            txtDbContext.AddUser(newUser);
            
            var text = File.ReadAllText(TestFilePath);
            // Assert
            var user = txtDbContext.GetUserById(2);
            Assert.IsNotNull(user);
            Assert.AreEqual("user2", user.Name);
        }

        [TestMethod]
        public void GetUserByCredentials_ShouldReturnCorrectUser()
        {
            // Arrange
            var txtDbContext = new TxtDbContext(TestFilePath);

            // Act
            var user = txtDbContext.GetUserByCredentials("user1", "password1");

            // Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void AddMealEntry_ShouldAddMealEntryToFile()
        {
            // Arrange  
            var txtDbContext = new TxtDbContext(TestFilePath);
            var newMealEntry = new MealEntry { Id = 2, FoodId = 2, Date = DateTime.Now, UserId = 1, PortionSize = 200 };

            // Act  
            txtDbContext.AddMealEntry(newMealEntry);

            // Assert  
            var mealEntries = txtDbContext.GetMealEntriesByUserId(1);
            Assert.AreEqual(2, mealEntries.Count);
        }
    }
}
