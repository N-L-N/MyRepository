using ProperDiet.Intefaces.Animation;
using ProperDiet.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProperDiet
{
    public partial class GeneralForm : Form
    {
        public GeneralForm()
        {
            InitializeComponent();
        }

        private IAnimElement animElement;

        private async void MenuButton_Click(object sender, EventArgs e)
        {
            if (animElement == null)
            {
                animElement = new AnimFlowLayotPanel(sidebarContainer, 30);
            }
            
            await animElement.Anim();
        }

        public void SetButtonColor(Button button, Color color)
        {
            button.BackColor = color;
        }
        private void LoadControl(UserControl control)
        {
            PagePanel.Controls.Clear();  // Очищаем панель от предыдущего контента

            PagePanel.Controls.Add(control);  // Добавляем UserControl в панель

            control.Dock = DockStyle.Fill;
            control.BringToFront();           // Перемещаем его на передний план
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[] 
            {settingsButton, addFoodButton, addFoodCategoryButton, foodCategoryButton});
            ButtonColor.SetButtonColorActive(homeButton);

            LoadControl(new HomeControl());
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[]
            {homeButton, addFoodButton, addFoodCategoryButton, foodCategoryButton});
            ButtonColor.SetButtonColorActive(settingsButton);
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[]
            {settingsButton, homeButton, addFoodCategoryButton, foodCategoryButton});
            ButtonColor.SetButtonColorActive(addFoodButton);
        }

        private void AddFoodCategoryButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[]
            {settingsButton, addFoodButton, homeButton, foodCategoryButton});
            ButtonColor.SetButtonColorActive(addFoodCategoryButton);
        }

        private void foodCategoryButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[]
            {settingsButton, addFoodButton, addFoodCategoryButton, homeButton});
            ButtonColor.SetButtonColorActive(foodCategoryButton);
        }
    }
}
