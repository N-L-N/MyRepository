using Guna.UI2.WinForms.Suite;
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

         private List<Entity.Food> _foods;

        public FoodBlock(int categoryId, FlowLayoutPanel blocksAdder)
        {
            _categoryId = categoryId;
            _blocksAdder = blocksAdder;
            _blocksAdder.Controls.Clear();

            txtDbContext = new TxtDbContext("data.txt");
        }

        public async void CreateBlockAsync()
        {
            try
            {
                await LoadFoodsAsync();
            }
            catch (Exception)
            {
                _blocksAdder.Controls.Add(new Label()
                {
                    Text = "Страница не загружена",
                    ForeColor = Color.LightGray,
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
                ForeColor = Color.LightGray,
                Location = new Point(3, 3),
                Name = "FoodBlock",
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Size = new Size(190, 220),
                TabIndex = 0,
                TabStop = false,
                BackColor = Color.FromArgb(31, 30, 45)
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
                TextAlign = ContentAlignment.MiddleLeft
            };

            foodBlock.Controls.Add(backLabel);
            _blocksAdder.Controls.Add(foodBlock);

            foodBlock.MouseClick += FoodBlock_Click;
            foodBlock.MouseMove += FoodBlock_MouseMove;
            foodBlock.MouseLeave += FoodBlock_MouseLeave;
        }

        private void FoodBlock_MouseLeave(object sender, EventArgs e)
        {
            (sender as GroupBox).BackColor = Color.FromArgb(31, 30, 45);
        }

        private void FoodBlock_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as GroupBox).BackColor = Color.FromArgb(20, 25, 45);
        }

        private void FoodBlock_Click(object sender, EventArgs e)
        {
            var myGroupBox = sender as GroupBox;
            myGroupBox.BackColor = Color.FromArgb(40, 37, 50);

            new ContextBlock(new CategoryBlock(_blocksAdder)).CreateBlock();
        }

        private void AddFoodBlock(string name, string description, string calories)
        {
            GroupBox foodBlock = new GroupBox
            {
                Text = name,
                ForeColor = Color.LightGray,
                Location = new Point(3, 3),
                Name = "FoodBlock",
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Size = new Size(190, 220),
                TabIndex = 0,
                TabStop = false,
                BackColor = Color.FromArgb(31, 30, 45)
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
                TextAlign = ContentAlignment.MiddleLeft
            };

            foodBlock.Controls.Add(descriptionLabel);
            _blocksAdder.Controls.Add(foodBlock);
        }
    }
}
