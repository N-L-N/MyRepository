using ProperDiet.Controls.Static;
using ProperDiet.Entity;
using ProperDiet.Services;
using ProperDiet.Services.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet
{
    public partial class AddFoodControl : UserControl
    {
        TxtDbContext txtDbContext;
        public AddFoodControl()
        {
            InitializeComponent();

            txtDbContext = new TxtDbContext("data.txt");

            UiMode.Update();

            ApplyTheme();

            UiMode.OnThemeChanged += ApplyTheme;
        }

        private void ApplyTheme()
        {
            this.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
            this.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;

            foreach (Control control in this.Controls)
            {
                ApplyThemeToControl(control);
            }
        }
        private void ApplyThemeToControl(Control control)
        {
            if (control is Button button)
            {
                // Кнопки темные в темной теме и светлые в светлой теме
                button.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
                button.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
            }
            else
            {
                // Остальные элементы формы окрашиваются по стандартной схеме
                control.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
                control.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
            }

            foreach (Control child in control.Controls)
            {
                ApplyThemeToControl(child);
            }
        }

        private async Task LoadCategoriesToComboBoxAsync(ComboBox comboBox)
        {
            try
            {
                // Очистка ComboBox перед загрузкой
                comboBox.Items.Clear();

                // Асинхронная загрузка категорий из файла
                var categories = await Task.Run(() => txtDbContext.GetCategories());

                // Добавление категорий в ComboBox
                foreach (var category in categories)
                {
                    comboBox.Items.Add(category.Name);
                }

                // Устанавливаем первый элемент как выбранный
                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки категорий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что категория выбрана
                if (cmbCategory.SelectedItem == null)
                {
                    MessageBox.Show("Выберите категорию из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Создаём новую запись еды
                var newFood = new Entity.Food
                {
                    Id = txtDbContext.GetLastFoodId() + 1, // Получаем новый уникальный ID
                    Name = txtFoodName.Text, // Имя еды
                    Description = txtFoodDescription.Text, // Описание еды
                    Calories = int.Parse(txtCalories.Text), // Калории
                    CategoryId = txtDbContext.FindCategoryIndexByName(cmbCategory.Text)// ID категории из ComboBox
                };

                // Добавляем еду в файл
                txtDbContext.AddFood(newFood);

                MessageBox.Show("Продукт успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем поля после добавления
                txtFoodName.Clear();
                txtFoodDescription.Clear();
                txtCalories.Clear();
                cmbCategory.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Ошибка добавления продукта: {0}", ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private async void AddFoodControl_Load(object sender, EventArgs e)
        {
            await LoadCategoriesToComboBoxAsync(cmbCategory);
        }

        private void panel5_Resize(object sender, EventArgs e)
        {
            this.AddFoodButton.Location = new System.Drawing.Point(
                (this.panel5.Width - this.AddFoodButton.Width) / 2,
                (this.panel5.Height - this.AddFoodButton.Height) / 2
            );
        }
    }
}
