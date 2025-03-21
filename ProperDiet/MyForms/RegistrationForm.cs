using ProperDiet.Controls.Static;
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
    public partial class RegistrationForm : Form
    {
        private TxtDbContext dbContext;
        private User User;
        public RegistrationForm()
        {
            InitializeComponent();

            dbContext = new TxtDbContext();

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

        private void VisiblePasswordCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (visiblePasswordCheck.Checked)
                passwordTextBox.UseSystemPasswordChar = true;
            else passwordTextBox.UseSystemPasswordChar = false;
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            string passwordUser = passwordTextBox.Text.Trim();

            string nameUser = nameTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(nameUser) &&
                !string.IsNullOrWhiteSpace(nameUser) &&
                nameUser.Length >= 3 &&
                nameUser.Length <= 30 &&
                !string.IsNullOrEmpty(passwordUser) &&
                !string.IsNullOrWhiteSpace(passwordUser) &&
                passwordUser.Length >= 3)
            {
                User = new User()
                {
                    Id = dbContext.GetLastUserId() + 1,
                    Name = nameUser,
                    Password = passwordUser
                };
                var continueForm = new ContinuationRegForm(User);

                continueForm.Show();

                this.Hide();
            }
            else MessageBox.Show(
                "Поля не должны быть пустыми и содержать не менее 3 символов или не более 30 символов", 
                "Информация", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question);
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            LogForm log = new LogForm();

            log.Show();

            this.Hide();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
