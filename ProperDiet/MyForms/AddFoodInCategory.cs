using ProperDiet.Controls.Static;
using ProperDiet.Entity;
using ProperDiet.Services.Data;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProperDiet.MyForms
{
    public partial class AddFoodInCategory : Form
    {
        private TxtDbContext dbContext;

        private int categoryId;
        public AddFoodInCategory(int categoryId)
        {
            InitializeComponent();

            dbContext = new TxtDbContext();

            UiMode.OnThemeChanged += ApplyTheme;

            ApplyTheme();

            this.categoryId = categoryId;
        }

        public AddFoodInCategory(TxtDbContext dbContext, int categoryId)
        {
            InitializeComponent();

            this.dbContext = dbContext;

            UiMode.OnThemeChanged += ApplyTheme;

            ApplyTheme();

            this.categoryId = categoryId;
        }

        public AddFoodInCategory(TxtDbContext dbContext, Category category)
        {
            InitializeComponent();

            this.dbContext = dbContext;

            UiMode.OnThemeChanged += ApplyTheme;

            ApplyTheme();

            this.categoryId = category.Id;
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = nameTextBox.Text.Trim();

            descriptionTextBox.Text = descriptionTextBox.Text.Trim();

            int calories = int.TryParse(caloriesTextBox.Text, out int result) ? result : 0;

            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Введите название продукта.");
                return;
            }

            if (calories == 0)
            {
                MessageBox.Show("Введите корректное значение калорийности.");
                return;
            }

            Food food = new Food
            {
                Id = dbContext.GetLastFoodId() + 1,
                CategoryId = categoryId,
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                Calories = calories
            };

            dbContext.AddFood(food);

            this.Hide();
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CaloriesTextBox_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = caloriesTextBox.SelectionStart;

            string filteredText = new string(caloriesTextBox.Text.Where(char.IsDigit).ToArray());

            caloriesTextBox.Text = filteredText;

            caloriesTextBox.SelectionStart = Math.Min(selectionStart, caloriesTextBox.Text.Length);
        }
    }
}
