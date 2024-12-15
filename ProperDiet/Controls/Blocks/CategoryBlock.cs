using ProperDiet.Intefaces.Blocks;
using ProperDiet.Services;
using ProperDiet.Services.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet.Controls.Blocks
{
    internal class CategoryBlock : IBlock
    {
        private readonly FlowLayoutPanel _blocksAdder;
        private List<Entity.Category> _categories;

        private TxtDbContext txtDb;

        public CategoryBlock(FlowLayoutPanel blocksAdder)
        {
            _blocksAdder = blocksAdder;
            _blocksAdder.Controls.Clear();

            txtDb = new TxtDbContext("data.txt");
        }

        public async void CreateBlockAsync()
        {
            try
            {
                await LoadCategoriesAsync();
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

        private async Task LoadCategoriesAsync()
        {
            var categories = await Task.Run(() => txtDb.GetCategories());
            _categories = categories;

            foreach (var category in categories)
            {
                AddCategoryBlock(category.Name, category.Description);
            }
        }

        private void AddCategoryBlock(string name, string description)
        {
            GroupBox categoryBlock = new GroupBox
            {
                Text = name,
                ForeColor = Color.LightGray,
                Location = new Point(3, 3),
                Name = "CategoryBlock",
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
                Text = description,
                TextAlign = ContentAlignment.MiddleLeft
            };

            categoryBlock.Controls.Add(descriptionLabel);
            categoryBlock.MouseClick += CategoryBlock_MouseClick;
            categoryBlock.MouseMove += CategoryBlock_MouseMove;
            categoryBlock.MouseLeave += CategoryBlock_MouseLeave;

            _blocksAdder.Controls.Add(categoryBlock);
        }

        private void CategoryBlock_MouseClick(object sender, MouseEventArgs e)
        {
            var myGroupBox = sender as GroupBox;
            myGroupBox.BackColor = Color.FromArgb(40, 37, 50);

            foreach (var category in _categories)
            {
                if (category.Name == myGroupBox.Text)
                {
                    new ContextBlock(new FoodBlock(category.Id, _blocksAdder))
                        .CreateBlock();
                    return;
                }
            }
        }

        private void CategoryBlock_MouseLeave(object sender, EventArgs e) =>
            (sender as GroupBox).BackColor = Color.FromArgb(31, 30, 45);

        private void CategoryBlock_MouseMove(object sender, MouseEventArgs e) =>
            (sender as GroupBox).BackColor = Color.FromArgb(20, 25, 45);
    }
}
