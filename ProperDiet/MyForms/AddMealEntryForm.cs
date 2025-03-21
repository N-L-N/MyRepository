using ProperDiet.Controls.Static;
using ProperDiet.Entity;
using ProperDiet.Models.Entity;
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
    public partial class AddMealEntryForm : Form
    {
        private TxtDbContext txtDbContext;

        public Food food;

        private User user;

        List<Entity.Food> foods;
        public AddMealEntryForm()
        {
            InitializeComponent();

            txtDbContext = new TxtDbContext();
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
        public AddMealEntryForm(int userId)
        {
            InitializeComponent();

            txtDbContext = new TxtDbContext();

            user = txtDbContext.GetUserById(userId);
        }
        public AddMealEntryForm(User user)
        {
            InitializeComponent();

            txtDbContext = new TxtDbContext();

            this.user = user;
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

        private async void AddMealEntryForm_Load(object sender, EventArgs e)
        {
            await LoadCategoriesToComboBoxAsync(categoryCombo);
        }

        private void AddButton_Click(object sender, EventArgs e)
        { 
            if (foodList.SelectedItems == null)
            {
                MessageBox.Show("Необходимо выбрать продукт", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                return;
            }

            food = foods[foodList.SelectedIndex];

            txtDbContext.AddMealEntry(new Models.Entity.MealEntry 
            { 
                Id = txtDbContext.GetLastMealEntryId() + 1, 
                Date = DateTime.Now, 
                FoodId = food.Id,
                UserId = user.Id,
            });

            this.DialogResult = DialogResult.OK;

            this.Hide();
        }

        private void FoodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CategoryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            foodList.Items.Clear();

            foods = txtDbContext.GetFoodsByCategory(categoryCombo.SelectedIndex + 1);
            
            foreach (var food in foods)
            {
                foodList.Items.Add(food.Name + ". Калории: " + food.Calories);
            }
        }

        
    }
}
