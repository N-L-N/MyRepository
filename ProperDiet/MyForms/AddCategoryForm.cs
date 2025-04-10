using ProperDiet.Controls.Static;
using ProperDiet.Entity;
using ProperDiet.Services.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProperDiet.MyForms
{
    public partial class AddCategoryForm: Form
    {
        private readonly TxtDbContext myDb;
        public AddCategoryForm(TxtDbContext txtDbContext)
        {
            InitializeComponent();

            myDb = txtDbContext;

            ApplyTheme();

            UiMode.OnThemeChanged += ApplyTheme;
        }

        public AddCategoryForm()
        {
            InitializeComponent();

            myDb = new TxtDbContext();

            UiMode.OnThemeChanged += ApplyTheme;

            ApplyTheme();
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

            if(nameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Введите название категории", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (myDb.FindCategoryByName(nameTextBox.Text) != null)
            {
                MessageBox.Show("Такая категория уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var category = new Category
            {
                Id = myDb.GetLastCategoryId() + 1,
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
            };

            myDb.AddCategory(category);

            MessageBox.Show("Категория успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
