using ProperDiet.Models.Entity;
using ProperDiet.Models.Enums;
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
    public partial class ContinuationRegForm : Form
    {
        private User User;

        private TxtDbContext txtDbContext;
        public ContinuationRegForm(User user)
        {
            InitializeComponent();

            this.User = user;

            txtDbContext = new TxtDbContext();
        }
        public ContinuationRegForm()
        {
            InitializeComponent();

            txtDbContext = new TxtDbContext();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            if (categoryDietCombo.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию тренировки", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if (GenderCombo.SelectedItem == null)
            {
                MessageBox.Show("Выберите пол", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            if(activityList.SelectedItems == null)
            {
                MessageBox.Show("Выберите активность", "Информация", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }
            Human human = new Human()
            {
                Id = txtDbContext.GetLastHumanId(),
                Height = (double)heightNumeric.Value,
                Age = (int)ageNumeric.Value,
                Weight = (int)weightNumeric.Value,
                CategoryDiet = (CategoryDiet)categoryDietCombo.SelectedIndex,
                Activity = (Activity)activityList.SelectedIndex,
                Gender = (Gender)GenderCombo.SelectedIndex,
            };

            this.User.HumanId = human.Id;

            txtDbContext.AddUser(User);

            txtDbContext.AddHuman(human);

            this.Hide();

            GeneralForm general = new GeneralForm(User, human); 

            general.Show();
        }
    }
}
