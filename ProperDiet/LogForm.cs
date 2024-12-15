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
