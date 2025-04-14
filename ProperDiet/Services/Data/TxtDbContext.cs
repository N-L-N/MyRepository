using ProperDiet.Entity;
using ProperDiet.Models.Entity;
using ProperDiet.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProperDiet.Services.Data
{
    public class TxtDbContext
    {
        private readonly string _filePath;

        /// <summary>
        /// Конструктор для инициализации контекста с файлом данных.
        /// </summary>
        /// <param name="filePath">Путь к файлу данных.</param>
        public TxtDbContext(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл {filePath} не найден.");
            }
            _filePath = filePath;
        }
        public TxtDbContext() 
        {
            _filePath = "data.txt";

            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException($"Файл {_filePath} не найден.");
            }
        }

        /// <summary>
        /// Метод добавления категории в файл.
        /// </summary>
        public void AddCategory(Entity.Category category)
        {
            var lines = File.ReadAllLines(_filePath).ToList();

            // Определяем, куда добавить новую категорию
            int categoryIndex = lines.FindIndex(line => line.StartsWith("# Еда"));
            if (categoryIndex == -1)
            {
                throw new InvalidOperationException("Файл не содержит секции '# Еда'.");
            }

            // Генерируем строку для категории
            string newCategoryLine = $"{category.Id};{category.Name};{category.Description}";

            // Добавляем категорию перед секцией '# Еда'
            lines.Insert(categoryIndex, newCategoryLine);

            // Сохраняем файл
            File.WriteAllLines(_filePath, lines);
        }

        /// <summary>
        /// Метод добавления еды в файл.
        /// </summary>
        public void AddFood(Entity.Food food)
        {
            var lines = File.ReadAllLines(_filePath).ToList();

            // Определяем, где начинается секция '# Еда'
            int foodIndex = lines.FindIndex(line => line.StartsWith("# Еда"));
            if (foodIndex == -1)
            {
                throw new InvalidOperationException("Файл не содержит секции '# Еда'.");
            }

            // Ищем конец секции '# Еда'
            int insertIndex = foodIndex + 1;
            while (insertIndex < lines.Count && !lines[insertIndex].StartsWith("#") && !string.IsNullOrWhiteSpace(lines[insertIndex]))
            {
                insertIndex++;
            }

            // Генерируем строку для еды
            string newFoodLine = $"{food.Id};{food.Name};{food.Description};{food.Calories};{food.CategoryId}";

            // Вставляем строку в нужное место
            lines.Insert(insertIndex, newFoodLine);

            // Сохраняем файл
            File.WriteAllLines(_filePath, lines);
        }

        /// <summary>
        /// Загружает все категории из текстового файла.
        /// </summary>
        /// <returns>Список категорий.</returns>
        public List<Entity.Category> GetCategories()
        {
            var lines = File.ReadAllLines(_filePath);
            var categories = new List<Entity.Category>();
            bool isCategorySection = false;

            foreach (var line in lines)
            {
                if (line.StartsWith("# Категории"))
                {
                    isCategorySection = true;
                    continue;
                }

                if (line.StartsWith("# Еда")) break;

                if (isCategorySection && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(';');
                    categories.Add(new Entity.Category
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Description = parts[2]
                    });
                }
            }

            return categories;
        }

        /// <summary>
        /// Загружает всю еду из текстового файла.
        /// </summary>
        /// <returns>Список продуктов.</returns>
        public List<Entity.Food> GetFoods()
        {
            var lines = File.ReadAllLines(_filePath);
            var foods = new List<Entity.Food>();
            bool isFoodSection = false;

            foreach (var line in lines)
            {
                if (line.StartsWith("# Еда"))
                {
                    isFoodSection = true;
                    continue;
                }

                if (isFoodSection && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(';');

                    // Проверка корректности данных
                    if (parts.Length != 5 ||
                        !int.TryParse(parts[0], out var id) ||
                        !int.TryParse(parts[3], out var calories) ||
                        !int.TryParse(parts[4], out var categoryId))
                    {
                        continue;
                    }

                    // Добавление продукта в список
                    foods.Add(new Entity.Food
                    {
                        Id = id,
                        Name = parts[1],
                        Description = parts[2],
                        Calories = calories,
                        CategoryId = categoryId
                    });
                }
            }

            return foods;
        }


        /// <summary>
        /// Получает список еды, относящейся к определённой категории.
        /// </summary>
        /// <param name="categoryId">Идентификатор категории.</param>
        /// <returns>Список еды.</returns>
        public List<Entity.Food> GetFoodsByCategory(int categoryId)
        {
            return GetFoods()
                .Where(f => f.CategoryId == categoryId)
                .ToList();
        }

        /// <summary>
        /// Получить последний ID категорий.
        /// </summary>
        /// <summary>
        /// Получить последний ID категории.
        /// </summary>
        public int GetLastCategoryId()
        {
            var lines = File.ReadAllLines(_filePath);
            int lastCategoryId = -1;

            bool inCategorySection = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("# Категории"))
                {
                    inCategorySection = true;
                }
                else if (inCategorySection && !line.StartsWith("#") && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(';');
                    if (parts.Length > 0 && int.TryParse(parts[0], out int id))
                    {
                        lastCategoryId = Math.Max(lastCategoryId, id);
                    }
                }
                else if (line.StartsWith("#"))
                {
                    inCategorySection = false;
                }
            }

            return lastCategoryId;
        }


        /// <summary>
        /// Получить последний ID еды.
        /// </summary>
        public int GetLastFoodId()
        {
            var lines = File.ReadAllLines(_filePath);
            int lastFoodId = -1;

            bool inFoodSection = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("# Еда"))
                {
                    inFoodSection = true;
                }
                else if (inFoodSection && !line.StartsWith("#") && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(';');
                    if (parts.Length > 0)
                    {
                        int id = int.Parse(parts[0]);
                        lastFoodId = Math.Max(lastFoodId, id);
                    }
                }
                else if (line.StartsWith("#"))
                {
                    inFoodSection = false;
                }
            }

            return lastFoodId;
        }

        /// <summary>
        /// Получает объект Food по уникальному идентификатору из файла.
        /// </summary>
        /// <param name="id">Уникальный идентификатор продукта.</param>
        /// <returns>Возвращает объект Food, если продукт с таким ID найден, иначе null.</returns>
        public Food GetFoodById(int id)
        {
            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split(';');
                if (parts.Length < 5) // Убедитесь, что данных достаточно для создания объекта Food
                    continue;

                if (int.Parse(parts[0]) == id)
                {
                    return new Food
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Description = parts[2],
                        Calories = int.Parse(parts[3]),
                        CategoryId = int.Parse(parts[4])
                    };
                }
            }

            return null;
        }

        /// <summary>
        /// Поиск индекса категории по имени.
        /// </summary>
        public int FindCategoryIndexByName(string categoryName)
        {
            var lines = File.ReadAllLines(_filePath);

            // Поиск строки категории
            foreach (var line in lines)
            {
                if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(';');
                if (parts.Length >= 2 && parts[1].Equals(categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    return int.Parse(parts[0]); // Возвращаем ID категории
                }
            }

            throw new KeyNotFoundException($"Категория с именем '{categoryName}' не найдена.");
        }

        /// <summary>
        /// Поиск категории по имени
        /// </summary>

        public Category FindCategoryByName(string categoryName)
        {
            var lines = File.ReadAllLines(_filePath);

            // Поиск строки категории
            foreach (var line in lines)
            {
                if (line.StartsWith("#") || string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(';');
                if (parts.Length >= 2 && parts[1].Equals(categoryName, StringComparison.OrdinalIgnoreCase))
                {
                    return new Category
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Description = parts[2],
                        Foods = GetFoodsByCategory(int.Parse(parts[0]))
                    }; 
                }
            }

            return null;
        }

        /// <summary>
        /// Поиск индекса еды по имени.
        /// </summary>
        public int FindFoodIndexByName(string foodName)
        {
            var lines = File.ReadAllLines(_filePath);
            bool isFoodSection = false;

            // Поиск строки еды
            foreach (var line in lines)
            {
                if (line.StartsWith("# Еда"))
                {
                    isFoodSection = true;
                    continue;
                }

                if (!isFoodSection || string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(';');
                if (parts.Length >= 2 && parts[1].Equals(foodName, StringComparison.OrdinalIgnoreCase))
                {
                    return int.Parse(parts[0]); // Возвращаем ID еды
                }
            }

            throw new KeyNotFoundException($"Еда с именем '{foodName}' не найдена.");
        }


        /// <summary>
        /// Добавить пользователя.
        /// </summary>
        public void AddUser(User user)
        {
            var lines = File.ReadAllLines(_filePath).ToList();

            // Находим секцию '# Пользователи'
            int categoryIndex = lines.FindIndex(line => line.StartsWith("# Пользователи"));

            // Если секции нет, добавляем ее в конец
            if (categoryIndex == -1)
            {
                lines.Add("# Пользователи");
                categoryIndex = lines.Count - 1; // Указываем индекс на новую секцию
            }

            // Ищем, где заканчиваются пользователи
            int insertIndex = categoryIndex + 1; // Начинаем сразу после заголовка
            while (insertIndex < lines.Count && !lines[insertIndex].StartsWith("#") && !string.IsNullOrWhiteSpace(lines[insertIndex]))
            {
                insertIndex++;
            }

            // Генерируем строку для нового пользователя
            string newUserLine = $"{user.Id};{user.Name};{user.Password};{user.HumanId}";

            // Вставляем строку
            lines.Insert(insertIndex, newUserLine);

            // Сохраняем файл
            File.WriteAllLines(_filePath, lines);
        }


        /// <summary>
        /// Получить последний ID User.
        /// </summary>
        public int GetLastUserId()
        {
            var lines = File.ReadAllLines(_filePath);
            int lastUserId = 1; // Значение по умолчанию, если пользователей нет

            bool inUserSection = false; // Флаг для отслеживания раздела пользователей
            foreach (var line in lines)
            {
                if (line.StartsWith("# Пользователи"))
                {
                    inUserSection = true; // Входим в раздел пользователей
                }
                else if (inUserSection && !line.StartsWith("#") && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(';'); // Разделяем строку
                    if (parts.Length > 0 && int.TryParse(parts[0], out int id)) // Проверяем корректность ID
                    {
                        lastUserId = Math.Max(lastUserId, id); // Обновляем максимальный ID
                    }
                }
                else if (line.StartsWith("#"))
                {
                    inUserSection = false; // Покидаем текущий раздел
                }
            }

            return lastUserId;
        }

        /// <summary>
        /// Получить пользователя по логину и паролю.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Объект User, если пользователь найден, иначе null.</returns>
        public User GetUserByCredentials(string login, string password)
        {
            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                // Пропускаем строки, которые начинаются с '#'
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                // Разбиваем строку на части
                var parts = line.Split(';');
                if (parts.Length < 4)
                    continue;

                // Преобразуем данные
                if (parts[1] == login && parts[2] == password)
                {
                    return new User
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Password = parts[2],
                        HumanId = int.Parse(parts[3])
                    };
                }
            }

            return null; // Пользователь не найден
        }

        /// <summary>
        /// Получить пользователя по ID
        /// </summary>
        /// <param name="id">Id пользователи.</param>
        /// <returns>Объект User, если пользователь найден, иначе null.</returns>
        public User GetUserById(int id)
        {
            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                // Пропускаем пустые строки и комментарии
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                // Разбиваем строку на части
                var parts = line.Split(';');
                if (parts.Length < 4) // Проверяем, что данных достаточно
                    continue;

                // Если первый элемент совпадает с заданным id, создаем объект User
                if (int.Parse(parts[0]) == id)
                {
                    return new User
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Password = parts[2],
                        HumanId = int.Parse(parts[3])
                    };
                }
            }

            return null; // Если пользователь с указанным id не найден
        }



        /// <summary>
        /// Добавить человека в файл.
        /// </summary>
        public void AddHuman(Human human)
        {
            var lines = File.Exists(_filePath)
                ? File.ReadAllLines(_filePath).ToList()
                : new List<string>();

            // Находим секцию '# Телосложение'
            int categoryIndex = lines.FindIndex(line => line.StartsWith("# Телосложение"));

            // Если секции нет, добавляем её в конец
            if (categoryIndex == -1)
            {
                lines.Add("# Телосложение");
                categoryIndex = lines.Count - 1; // Индекс новой секции
            }

            // Ищем место вставки (после заголовка или перед новой секцией)
            int insertIndex = categoryIndex + 1;
            while (insertIndex < lines.Count && !lines[insertIndex].StartsWith("#") && !string.IsNullOrWhiteSpace(lines[insertIndex]))
            {
                insertIndex++;
            }

            // Генерируем строку для нового человека
            string newHumanLine = $"{human.Id};{human.Height};{human.Age};{human.Weight};" +
                                  $"{human.CategoryDiet};{human.Gender};{human.Activity};";

            // Вставляем строку
            lines.Insert(insertIndex, newHumanLine);

            // Сохраняем изменения в файл
            File.WriteAllLines(_filePath, lines);
        }

        /// <summary>
        /// Получить последний ID Human.
        /// </summary>
        public int GetLastHumanId()
        {
            var lines = File.ReadAllLines(_filePath);
            int lastUserId = 1; // Значение по умолчанию, если пользователей нет

            bool inUserSection = false; // Флаг для отслеживания раздела пользователей
            foreach (var line in lines)
            {
                if (line.StartsWith("# Телосложение"))
                {
                    inUserSection = true; // Входим в раздел пользователей
                }
                else if (inUserSection && !line.StartsWith("#") && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split(';'); // Разделяем строку
                    if (parts.Length > 0 && int.TryParse(parts[0], out int id)) // Проверяем корректность ID
                    {
                        lastUserId = Math.Max(lastUserId, id); // Обновляем максимальный ID
                    }
                }
                else if (line.StartsWith("#"))
                {
                    inUserSection = false; // Покидаем текущий раздел
                }
            }

            return lastUserId;
        }

        /// <summary>
        /// Получить объект Human по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор Human.</param>
        /// <returns>Объект Human, если найден, иначе null.</returns>
        public Human GetHumanById(int id)
        {
            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split(';');
                if (parts.Length < 7)
                    continue;

                if (int.Parse(parts[0]) == id)
                {
                    return new Human
                    {
                        Id = int.Parse(parts[0]),
                        Height = double.Parse(parts[1]),
                        Age = int.Parse(parts[2]),
                        Weight = double.Parse(parts[3]),
                        CategoryDiet = (CategoryDiet)Enum.Parse(typeof(CategoryDiet), parts[4]),
                        Gender = (Gender)Enum.Parse(typeof(Gender), parts[5]),
                        Activity = (Activity)Enum.Parse(typeof(Activity), parts[6])
                    };
                }
            }

            return null;
        }



        /// <summary>
        /// Добавляет запись о приеме пищи в файл.
        /// </summary>
        /// <param name="mealEntry">Объект MealEntry, который нужно добавить.</param>
        public void AddMealEntry(MealEntry mealEntry)
        {
            var lines = File.Exists(_filePath)
                ? File.ReadAllLines(_filePath).ToList()
                : new List<string>();

            // Находим секцию '# Прием пищи'
            int categoryIndex = lines.FindIndex(line => line.StartsWith("# Прием пищи"));

            // Если секции нет, добавляем её в конец
            if (categoryIndex == -1)
            {
                lines.Add("# Прием пищи");
                categoryIndex = lines.Count - 1; // Индекс новой секции
            }

            // Ищем место вставки (после заголовка или перед новой секцией)
            int insertIndex = categoryIndex + 1;
            while (insertIndex < lines.Count && !lines[insertIndex].StartsWith("#") && !string.IsNullOrWhiteSpace(lines[insertIndex]))
            {
                insertIndex++;
            }

            // Генерируем строку для новой записи о приеме пищи
            string newMealEntryLine = $"{mealEntry.Id};{mealEntry.FoodId};{mealEntry.Date:yyyy-MM-dd};{mealEntry.UserId};{mealEntry.PortionSize}";

            // Вставляем строку
            lines.Insert(insertIndex, newMealEntryLine);

            // Сохраняем изменения в файл
            File.WriteAllLines(_filePath, lines);
        }


        /// <summary>
        /// Получить список записей о приеме пищи по идентификатору пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Список объектов MealEntry, если найдены записи, иначе пустой список.</returns>
        public List<MealEntry> GetMealEntriesByUserId(int userId)
        {
            var lines = File.ReadAllLines(_filePath);
            var mealEntries = new List<MealEntry>(); // Список для хранения записей

            foreach (var line in lines)
            {
                // Пропускаем пустые строки и комментарии
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split(';'); // Разделяем строку по разделителю ';'

                // Проверяем наличие минимального количества элементов
                if (parts.Length < 4)
                    continue;

                // Пробуем преобразовать данные
                if (int.TryParse(parts[0], out int id) &&
                    int.TryParse(parts[1], out int foodId) &&
                    DateTime.TryParse(parts[2], out DateTime date) &&
                    int.TryParse(parts[3], out int currentUserId) &&
                    int.TryParse(parts[4], out int portionSize)) 
                    
                {
                    // Логируем отладочную информацию
                    Console.WriteLine($"Обработана строка: {line}");
                    Console.WriteLine($"ID: {id}, FoodId: {foodId}, Date: {date}, UserId: {currentUserId}");

                    // Добавляем запись только если UserId совпадает
                    if (currentUserId == userId)
                    {
                        mealEntries.Add(new MealEntry
                        {
                            Id = id,
                            FoodId = foodId,
                            Date = date,
                            UserId = currentUserId,
                            PortionSize = portionSize
                        });
                    }
                }
                else
                {
                    // Логируем некорректные строки
                    Console.WriteLine($"Пропущена строка: {line}");
                }
            }

            return mealEntries;
        }

        /// <summary>
        /// Получить список записей о приеме пищи по идентификатору пользователя и указанной дате.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="dateTime">Дата для фильтрации записей.</param>
        /// <returns>Список объектов MealEntry, если найдены записи, иначе пустой список.</returns>
        public List<MealEntry> GetMealEntriesByUserIdAndByDateTime(int userId, DateTime dateTime)
        {
            var lines = File.ReadAllLines(_filePath);
            var mealEntries = new List<MealEntry>(); // Список для хранения записей

            foreach (var line in lines)
            {
                // Пропускаем пустые строки и комментарии
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split(';'); // Разделяем строку по разделителю ';'

                // Проверяем наличие минимального количества элементов
                if (parts.Length < 4)
                    continue;

                // Пробуем преобразовать данные
                if (int.TryParse(parts[0], out int id) &&
                    int.TryParse(parts[1], out int foodId) &&
                    DateTime.TryParse(parts[2], out DateTime date) &&
                    int.TryParse(parts[3], out int currentUserId) &&
                    int.TryParse(parts[4], out int portionSize)) 
                {
                    // Проверяем совпадение userId и даты
                    if (currentUserId == userId && date.Date == dateTime.Date)
                    {
                        mealEntries.Add(new MealEntry
                        {
                            Id = id,
                            FoodId = foodId,
                            Date = date,
                            UserId = currentUserId,
                            PortionSize = portionSize
                        });
                    }
                }
                else
                {
                    // Логируем некорректные строки для отладки
                    Console.WriteLine($"Пропущена строка: {line}");
                }
            }

            return mealEntries;
        }
        /// Получить последний идентификатор записи о приеме пищи.
        /// </summary>
        /// <returns>Последний идентификатор записи о приеме пищи или 1, если записей нет.</returns>
        public int GetLastMealEntryId()
        {
            var lines = File.ReadAllLines(_filePath);
            int lastMealEntryId = 1; // Значение по умолчанию, если записей нет

            foreach (var line in lines)
            {
                // Пропускаем комментарии и пустые строки
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var parts = line.Split(';'); // Разделяем строку на части
                if (parts.Length > 0 && int.TryParse(parts[0], out int id))
                {
                    // Обновляем максимальный ID
                    lastMealEntryId = Math.Max(lastMealEntryId, id);
                }
            }

            return lastMealEntryId;
        }
    }}

