using ProperDiet.Animation;
using ProperDiet.Entity;
using ProperDiet.Intefaces.Animation;
using ProperDiet.Intefaces.Blocks;
using ProperDiet.Models.Entity;
using ProperDiet.Services.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet.Controls.Blocks
{
    internal class MealEntryBlock : IBlock
    {
        private readonly Panel _container; // Панель-контейнер для блоков
        private readonly int _userId; // ID пользователя для загрузки данных
        private readonly TxtDbContext _dbContext; // Контекст базы данных

        public MealEntryBlock(Panel container, int userId, TxtDbContext dbContext)
        {
            _container = container;
            _container.Controls.Clear(); // Очищаем перед добавлением блоков
            _userId = userId;
            _dbContext = dbContext;
        }

        public async void CreateBlockAsync()
        {
            try
            {
                var mealEntries = await LoadMealEntriesAsync();
                if (mealEntries == null)
                {
                    mealEntries = new List<MealEntry>();  // Защита от null
                }
                AddBlocks(mealEntries);
            }
            catch (Exception ex)
            {
                _container.Controls.Add(new Label()
                {
                    Text = $"Ошибка загрузки данных: {ex.Message}",
                    ForeColor = Color.Red,
                    Font = new Font("Arial", 12F),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Top
                });
            }
        }


        private async Task<List<MealEntry>> LoadMealEntriesAsync()
        {
            // Загружаем записи из базы данных
            return await Task.Run(() => _dbContext.GetMealEntriesByUserId(_userId));
        }

        private void AddBlocks(List<MealEntry> mealEntries)
        {
            int yOffset = 10; // Начальный отступ сверху

            // Группируем записи по дате
            var groupedEntries = mealEntries.GroupBy(entry => entry.Date.Date);

            foreach (var group in groupedEntries)
            {
                // Формируем список еды для текущей даты
                var foodDetails = group
                    .Select(entry => _dbContext.GetFoodById(entry.FoodId))
                    .Where(food => food != null)
                    .Select(food => (food.Name, food.Description, food.Calories)) // Добавляем калории
                    .ToList();

                if (foodDetails.Count > 0)
                {
                    var totalCalories = foodDetails.Sum(fd => fd.Calories); // Считаем калории за день
                    var block = CreateBlock(group.Key, foodDetails, totalCalories, yOffset);
                    _container.Controls.Add(block);
                    yOffset += block.Height + 10; // Смещение для следующего блока
                }
            }

            _container.Controls.Add(AddPanelAdding());
        }




        private Panel AddPanelAdding()
        {
            Panel addPanel = new Panel()
            {
                BackColor = Color.FromArgb(31, 30, 45),
                Dock = DockStyle.Top,
                Size = new Size(0, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
            };
            Button addButton = new Button()
            {
                ForeColor = Color.LightGray,
                Text = "Добавить еду",
                Size = new Size(400, 50),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(31, 30, 45)
            };

            addPanel.Controls.Add(addButton);

            CenterButton(addButton, addPanel);

            addPanel.Resize += (sender, e) =>
            {
                CenterButton(addButton, addPanel);
            };

            addButton.Click += (sender, e) =>
            {
                using (var addForm = new AddMealEntryForm(_userId))
                {
                    if (addForm.ShowDialog() == DialogResult.OK) // Проверяем результат формы
                    {
                        // Обновляем содержимое панели после добавления записи
                        ReloadBlocks();
                    }
                }
            };

            return addPanel;
        }

        private void ReloadBlocks()
        {
            _container.Controls.Clear(); // Удаляем все элементы с панели
            CreateBlockAsync(); // Пересоздаем блоки
        }


        private void CenterButton(Button button, Panel panel)
        {
            button.Location = new Point(
                (panel.Width - button.Width) / 2, // Центр по горизонтали
                (panel.Height - button.Height) / 2 // Центр по вертикали
            );
        }

        private Panel CreateBlock(DateTime date, List<(string Name, string Description, int Calories)> foodDetails, int totalCalories, int yOffset)
        {
            // Панель для одного блока
            Panel blockPanel = new Panel
            {
                BackColor = Color.FromArgb(31, 30, 45),
                Dock = DockStyle.Top,
                Size = new Size(0, 100),
                Location = new Point(10, yOffset),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
            };

            // Метка с датой
            Label dateLabel = new Label
            {
                Text = $"Дата: {date:dd MMMM yyyy}",
                Font = new Font("Microsoft Sans Serif", 14f),
                ForeColor = Color.LightGray,
                AutoSize = true,
                Dock = DockStyle.Top
            };
            blockPanel.Controls.Add(dateLabel);

            // Описание еды
            Label descriptionLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 12F),
                ForeColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(10, 50)
            };

            // Формируем текст описания еды
            var descriptionText = string.Join("\n", foodDetails.Select(fd => $"Еда: {fd.Name}\nОписание: {fd.Description}\n"));
            descriptionLabel.Text = descriptionText;

            blockPanel.Controls.Add(descriptionLabel);

            // Метка с калориями
            Label caloriesLabel = new Label
            {
                Text = $"Общее количество калорий: {totalCalories}",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.LightGray,
                AutoSize = true,
                Location = new Point(10, descriptionLabel.Bottom + 10),
            };
            blockPanel.Controls.Add(caloriesLabel);

            // Корректируем размер панели в зависимости от расположения калорий
            blockPanel.Size = new Size(blockPanel.Width, caloriesLabel.Bottom + 10);

            return blockPanel;
        }


        private void UpdateButtonPosition(Button button, Panel panel)
        {
            button.Location = new Point(
                panel.Width - button.Width - panel.Padding.Right,
                panel.Padding.Top
            );
        }

        private void UpdateLabelRightPosition(Label label, Panel panel)
        {
            label.Location = new Point(
                panel.Width - label.Width - panel.Padding.Right, // Расположить по правому краю с учётом отступа
                panel.Height - label.Height - panel.Padding.Bottom // Расположить по нижнему краю с учётом отступа
            );
        }
    }
}



