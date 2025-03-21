using ProperDiet.Controls.Static;
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
