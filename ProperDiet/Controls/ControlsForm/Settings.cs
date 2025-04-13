using System;
using System.Drawing;
using System.Windows.Forms;
using ProperDiet.Controls.Static;
using ProperDiet.Properties;


namespace ProperDiet
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();

            UiMode.Update();

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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();

            form.Hide();

            RegistrationForm registrationForm = new RegistrationForm();

            registrationForm.Show();
        }

        private void MyToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (myToggleButton1.Checked)
            {
                BlackColor();
            }
            else
            {
                WhiteColor();
            }
        }

        private void WhiteColor()
        {
            myToggleButton1.CheckState = CheckState.Unchecked;

            exitButton.Image = Resources.icons8_exit_25_1_;
            exitButton.ForeColor = Color.Black;

            this.ForeColor = Color.Black;
            this.BackColor = Color.Snow;

            UiMode.LightMode();
        }

        private void BlackColor()
        {
            myToggleButton1.CheckState = CheckState.Checked;

            exitButton.Image = Resources.icons8_exit_25;
            exitButton.ForeColor = Color.Snow;

            this.ForeColor = Color.Snow;
            this.BackColor = Color.Black;

            UiMode.DarkMode();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            if (UiMode.IsDarkMode)
            {
                BlackColor();
            }
            else
            {
                WhiteColor();
            }
        }
    }
}
