using ProperDiet.Animation;
using ProperDiet.Controls.Static;
using ProperDiet.Entity;
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
        private readonly Panel _container;
        private readonly int _userId;
        private readonly TxtDbContext _dbContext;

        public MealEntryBlock(Panel container, int userId, TxtDbContext dbContext)
        {
            _container = container;
            _container.Controls.Clear();
            _userId = userId;
            _dbContext = dbContext;

            UiMode.OnThemeChanged += ApplyTheme; 
        }

        public async void CreateBlockAsync()
        {
            try
            {
                var mealEntries = await LoadMealEntriesAsync();
                if (mealEntries == null) 
                {
                    mealEntries = new List<MealEntry>();
                }

                AddBlocks(mealEntries);
                ApplyTheme(); 
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
            return await Task.Run(() => _dbContext.GetMealEntriesByUserId(_userId));
        }

        private void AddBlocks(List<MealEntry> mealEntries)
        {
            int yOffset = 10;

            var groupedEntries = mealEntries.GroupBy(entry => entry.Date.Date);

            foreach (var group in groupedEntries)
            {
                var foodDetails = group
                    .Select(entry =>
                    {
                        var food = _dbContext.GetFoodById(entry.FoodId);
                        if (food != null)
                        {
                            // Учитываем размер порции для расчета калорий  
                            int calories = (food.Calories * entry.PortionSize) / 100;
                            return (Name: food.Name, Description: food.Description, Calories: calories);
                        }
                        return (Name: (string)null, Description: (string)null, Calories: 0);
                    })
                    .Where(fd => fd.Name != null)
                    .ToList();

                if (foodDetails.Count > 0)
                {
                    var totalCalories = foodDetails.Sum(fd => fd.Calories);
                    var block = CreateBlock(group.Key, foodDetails, totalCalories, yOffset);
                    _container.Controls.Add(block);
                    yOffset += block.Height + 10;
                }
            }

            _container.Controls.Add(AddPanelAdding());
        }

        private Panel AddPanelAdding()
        {
            Panel addPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Size = new Size(0, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
            };

            Button addButton = new Button()
            {
                Text = "Добавить еду",
                Size = new Size(400, 50),
                FlatStyle = FlatStyle.Flat,
            };

            addPanel.Controls.Add(addButton);
            CenterButton(addButton, addPanel);

            addPanel.Resize += (sender, e) => CenterButton(addButton, addPanel);

            addButton.Click += (sender, e) =>
            {
                using (var addForm = new AddMealEntryForm(_userId))
                {
                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        ReloadBlocks();
                    }
                }
            };

            ApplyThemeToControl(addPanel);
            return addPanel;
        }

        private void ReloadBlocks()
        {
            _container.Controls.Clear();
            CreateBlockAsync();
        }

        private void CenterButton(Button button, Panel panel)
        {
            button.Location = new Point(
                (panel.Width - button.Width) / 2,
                (panel.Height - button.Height) / 2
            );
        }

        private Panel CreateBlock(DateTime date, List<(string Name, string Description, int Calories)> foodDetails, int totalCalories, int yOffset)
        {
            Panel blockPanel = new Panel
            {
                Dock = DockStyle.Top,
                Size = new Size(0, 100),
                Location = new Point(10, yOffset),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10),
            };

            Label dateLabel = new Label
            {
                Text = $"Дата: {date:dd MMMM yyyy}",
                Font = new Font("Microsoft Sans Serif", 14f),
                AutoSize = true,
                Dock = DockStyle.Top
            };
            blockPanel.Controls.Add(dateLabel);

            Label descriptionLabel = new Label
            {
                Font = new Font("Microsoft Sans Serif", 12F),
                AutoSize = true,
                Location = new Point(10, 50)
            };

            var descriptionText = string.Join("\n", foodDetails.Select(fd => $"Еда: {fd.Name}\nОписание: {fd.Description}\n"));
            descriptionLabel.Text = descriptionText;
            blockPanel.Controls.Add(descriptionLabel);

            Label caloriesLabel = new Label
            {
                Text = $"Общее количество калорий: {totalCalories}",
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, descriptionLabel.Bottom + 10),
            };
            blockPanel.Controls.Add(caloriesLabel);

            blockPanel.Size = new Size(blockPanel.Width, caloriesLabel.Bottom + 10);

            ApplyThemeToControl(blockPanel);
            return blockPanel;
        }

        private void ApplyTheme()
        {
            _container.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;

            foreach (Control control in _container.Controls)
            {
                ApplyThemeToControl(control);
            }
        }

        private void ApplyThemeToControl(Control control)
        {
            if (control is Panel panel)
            {
                panel.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
            }
            else if (control is Button button)
            {
                button.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
                button.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
            }
            else if (control is Label label)
            {
                label.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
            }

            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child);
            }
        }
    }
}

