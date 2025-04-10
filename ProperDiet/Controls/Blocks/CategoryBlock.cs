using ProperDiet.Controls.Static;
using ProperDiet.Entity;
using ProperDiet.Intefaces.Blocks;
using ProperDiet.MyForms;
using ProperDiet.Properties;
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
using System.Xml.Linq;

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

            UiMode.OnThemeChanged += ApplyTheme;
        }

        public async void CreateBlockAsync()
        {
            try
            {
                await LoadCategoriesAsync();
                ApplyTheme();
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

        private async Task LoadCategoriesAsync()
        {
            _categories = await Task.Run(() => txtDb.GetCategories());
            foreach (var category in _categories)
            {
                AddCategoryBlock(category.Name, category.Description, category.Id);
            }
            AddCategoryButton();
        }

        private void AddCategoryButton()
        {
            Button buttonAdd = new Button
            {
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(190, 220),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Image = Resources.forButtonAdd_white
            };

            buttonAdd.Click += ButtonAdd_Click;

            _blocksAdder.Controls.Add(buttonAdd);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddCategoryForm category = new AddCategoryForm();

            category.ShowDialog();

            _blocksAdder.Controls.Clear();

            CreateBlockAsync();
        }

        private void AddCategoryBlock(string name, string description, int categoryId)
        {
            GroupBox categoryBlock = new GroupBox
            {
                Text = name,
                ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black,
                Location = new Point(3, 3),
                Name = "CategoryBlock",
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 204),
                Size = new Size(190, 220),
                TabIndex = 0,
                TabStop = false,
                BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow,
                Tag = categoryId // Сохраняем ID категории в Tag
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
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black
            };

            categoryBlock.Controls.Add(descriptionLabel);

            // Подключаем события клика, наведения и выхода
            categoryBlock.MouseClick += CategoryBlock_MouseClick;
            categoryBlock.MouseMove += CategoryBlock_MouseMove;
            categoryBlock.MouseLeave += CategoryBlock_MouseLeave;

            _blocksAdder.Controls.Add(categoryBlock);
        }

        private void CategoryBlock_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is GroupBox categoryBlock)
            {
                int categoryId = (int)categoryBlock.Tag; // Получаем ID категории

                categoryBlock.BackColor = UiMode.IsDarkMode ? Color.FromArgb(40, 37, 50) : Color.FromArgb(200, 200, 200);

                // Открываем FoodBlock с выбранной категорией
                new ContextBlock(new FoodBlock(categoryId, _blocksAdder)).CreateBlock();
            }
        }

        private void CategoryBlock_MouseLeave(object sender, EventArgs e)
        {
            if (sender is GroupBox categoryBlock)
            {
                categoryBlock.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
            }
        }

        private void CategoryBlock_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is GroupBox categoryBlock)
            {
                categoryBlock.BackColor = UiMode.IsDarkMode ? Color.FromArgb(20, 25, 45) : Color.FromArgb(230, 230, 230);
            }
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
            else if (control is Button button)
            {
                button.Image = UiMode.IsDarkMode ? Resources.forButtonAdd_white : Resources.forButtonAdd_black;
            }

            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child);
            }
        }
    }
}
