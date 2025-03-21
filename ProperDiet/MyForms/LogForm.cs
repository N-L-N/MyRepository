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
    public partial class LogForm : Form
    {
        private TxtDbContext context;
        public LogForm()
        {
            InitializeComponent();

            context = new TxtDbContext();

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

        private void LogButton_Click(object sender, EventArgs e)
        {
            string login = nameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            User user = context.GetUserByCredentials(login, password);

            if (user == null) 
            {
                MessageBox.Show("Неверный логин и пароль", "Авторизация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            Human human = context.GetHumanById(user.HumanId);
            
            GeneralForm form = new GeneralForm(user, human);

            this.Hide();

            form.Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            RegistrationForm form = new RegistrationForm();

            form.Show();
        }
    }
}
