using ProperDiet.Services.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet
{
    public partial class AddCategoryControl : UserControl
    {

        private TxtDbContext _dbContext;
        public AddCategoryControl()
        {
            InitializeComponent();

            _dbContext = new TxtDbContext("data.txt");
        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            this.AddButton.Location = new System.Drawing.Point(
                (this.panel3.Width - this.AddButton.Width) / 2,
                (this.panel3.Height - this.AddButton.Height) / 2
            );
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на пустые значения
                string categoryName = nameCategoryTextBox.Text.Trim();
                string categoryDescription = descriptionCategoryRich.Text.Trim();

                if (string.IsNullOrWhiteSpace(categoryName))
                {
                    MessageBox.Show("Название категории не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(categoryDescription))
                {
                    MessageBox.Show("Описание категории не может быть пустым.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создание новой категории
                var newCategory = new Entity.Category
                {
                    Id = _dbContext.GetLastCategoryId() + 1,
                    Name = categoryName,
                    Description = categoryDescription,
                };

                // Добавление в базу данных
                _dbContext.AddCategory(newCategory);

                // Уведомление об успешном добавлении
                MessageBox.Show("Категория успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очистка полей ввода
                nameCategoryTextBox.Clear();
                descriptionCategoryRich.Clear();
            }
            catch (Exception ex)
            {
                // Обработка возможных ошибок
                MessageBox.Show($"Произошла ошибка при добавлении категории: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
