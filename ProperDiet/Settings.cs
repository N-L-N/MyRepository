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
    public partial class Settings : UserControl
    {
        
        public Settings()
        {
            InitializeComponent();
        }

        private void Panel2_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Form form = this.FindForm();

            form.Hide();

            RegistrationForm registrationForm = new RegistrationForm();

            registrationForm.Show();
        }
    }
}
