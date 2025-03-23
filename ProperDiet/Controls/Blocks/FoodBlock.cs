using ProperDiet.Controls.Static;
using ProperDiet.Intefaces.Blocks;
using ProperDiet.Services;
using ProperDiet.Services.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProperDiet.Controls.Blocks
{
    internal class FoodBlock : IBlock
    {
        private readonly int _categoryId;
        private FlowLayoutPanel _blocksAdder;
        private TxtDbContext txtDbContext;

        public FoodBlock(int categoryId, FlowLayoutPanel blocksAdder)
        {
            _categoryId = categoryId;
            _blocksAdder = blocksAdder;
            _blocksAdder.Controls.Clear();

            txtDbContext = new TxtDbContext("data.txt");

            UiMode.OnThemeChanged += ApplyTheme; // Подписываемся на смену темы
        }

        public async void CreateBlockAsync()
        {
            try
            {
                await LoadFoodsAsync();
                ApplyTheme(); // Применяем тему после загрузки блоков
            }
            catch (Exception)
            {
                _blocksAdder.Controls.Add(new Label()
                {
                    Text = "Страница не загружена",
                    ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black,
                    Font = new Font("Arial", 12f),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true
                });
            }
        }

        private async Task LoadFoodsAsync()
        {
            var foods = await Task.Run(() => txtDbContext.GetFoods());
            var filteredFoods = foods.Where(f => f.CategoryId == _categoryId).ToList();

            foreach (var food in filteredFoods)
            {
                AddFoodBlock(food.Name, food.Description, food.Calories.ToString());
            }

            BackCategory();
        }

        private void BackCategory()
        {
            GroupBox foodBlock = new GroupBox
            {
                Text = "Назад",
                ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black,
                Location = new Point(3, 3),
                Name = "FoodBlock",
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Size = new Size(190, 220),
                TabIndex = 0,
                TabStop = false,
                BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow
            };

            Label backLabel = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(150, 0),
                Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Location = new Point(6, 20),
                Name = "descriptionLabel",
                TabIndex = 1,
                Text = $"Вернуться назад",
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black
            };

            foodBlock.Controls.Add(backLabel);
            _blocksAdder.Controls.Add(foodBlock);

            foodBlock.MouseClick += FoodBlock_Click;
            foodBlock.MouseMove += FoodBlock_MouseMove;
            foodBlock.MouseLeave += FoodBlock_MouseLeave;
        }

        private void FoodBlock_MouseLeave(object sender, EventArgs e)
        {
            (sender as GroupBox).BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
        }

        private void FoodBlock_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as GroupBox).BackColor = UiMode.IsDarkMode ? Color.FromArgb(20, 25, 45) : Color.FromArgb(230, 230, 230);
        }

        private void FoodBlock_Click(object sender, EventArgs e)
        {
            var myGroupBox = sender as GroupBox;
            myGroupBox.BackColor = UiMode.IsDarkMode ? Color.FromArgb(40, 37, 50) : Color.FromArgb(200, 200, 200);

            new ContextBlock(new CategoryBlock(_blocksAdder)).CreateBlock();
        }

        private void AddFoodBlock(string name, string description, string calories)
        {
            GroupBox foodBlock = new GroupBox
            {
                Text = name,
                ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black,
                Location = new Point(3, 3),
                Name = "FoodBlock",
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Size = new Size(190, 220),
                TabIndex = 0,
                TabStop = false,
                BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow
            };

            Label descriptionLabel = new Label
            {
                AutoSize = true,
                MaximumSize = new Size(150, 0),
                Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Location = new Point(6, 20),
                Name = "descriptionLabel",
                TabIndex = 1,
                Text = $"{description}\n\n{calories} кал. на 100г(мл).",
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black
            };

            foodBlock.Controls.Add(descriptionLabel);
            _blocksAdder.Controls.Add(foodBlock);
        }

        private void ApplyTheme()
        {
            _blocksAdder.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;

            foreach (Control control in _blocksAdder.Controls)
            {
                ApplyThemeToControl(control);
            }
        }

        private void ApplyThemeToControl(Control control)
        {
            if (control is GroupBox groupBox)
            {
                groupBox.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
                groupBox.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
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
