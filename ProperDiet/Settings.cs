using System;
using System.Drawing;
using System.Windows.Forms;
using ProperDiet.Controls.Static;


namespace ProperDiet
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();

            UiMode.Update();
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

            exitButton.Image = Image.FromFile("F:\\ProperDiet\\ProperDiet\\Resources\\icons8-exit-25(1).png");
            exitButton.ForeColor = Color.Black;

            this.ForeColor = Color.Black;
            this.BackColor = Color.Snow;

            UiMode.LightMode();
        }

        private void BlackColor()
        {
            myToggleButton1.CheckState = CheckState.Checked;

            exitButton.Image = Image.FromFile("F:\\ProperDiet\\ProperDiet\\Resources\\icons8-exit-25.png");
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
