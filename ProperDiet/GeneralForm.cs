using ProperDiet.Intefaces.Animation;
using ProperDiet.Models.Entity;
using ProperDiet.Services.Calculator;
using ProperDiet.Services.Data;
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
        CalculatorCalories calculator;
        private User _user;

        private Human _human;

        private TxtDbContext _txtDbContext;
        public GeneralForm(User user, Human human)
        {
            InitializeComponent();

            _user = user;

            _human = human;

            calculator = new CalculatorCalories(_human);
            
            NameUser.Text = _user.Name;

            _txtDbContext = new TxtDbContext();

            CalculateCalories();
        }

       
        private IAnimElement animElement;

        private void CalculateCalories()
        {
            // Получаем записи о приеме пищи текущего пользователя за текущую дату
            var mealEntries = _txtDbContext.GetMealEntriesByUserIdAndByDateTime(_user.Id, DateTime.Now);

            int maxCaloriesNumber = calculator.Calories; // Начальное количество калорий

            foreach (var mealEntry in mealEntries)
            {
                // Получаем информацию о пище по идентификатору
                var food = _txtDbContext.GetFoodById(mealEntry.FoodId);

                // Вычитаем калории из доступного лимита
                maxCaloriesNumber -= food.Calories;
            }

            // Обновляем текстовое поле с оставшимися калориями
            maxCalories.Text = $"Калории: {maxCaloriesNumber}";
        }

        private async void MenuButton_Click(object sender, EventArgs e)
        {
            if (animElement == null)
            {
                animElement = new AnimFlowLayotPanel(sidebarContainer, 30);
            }
            
            await animElement.Anim();
        }

        private void LoadControl(UserControl control)
        {
            PagePanel.Controls.Clear();  // Очищаем панель от предыдущего контента

            PagePanel.Controls.Add(control);  // Добавляем UserControl в панель

            control.Dock = DockStyle.Fill;
            control.BringToFront();           // Перемещаем его на передний план

            CalculateCalories();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[] 
            {settingsButton, addFoodButton, addFoodCategoryButton, foodCategoryButton});
            ButtonColor.SetButtonColorActive(homeButton);

            LoadControl(new HomeControl(_user));
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[]
            {homeButton, addFoodButton, addFoodCategoryButton, foodCategoryButton});
            ButtonColor.SetButtonColorActive(settingsButton);

            LoadControl(new Settings());
        }

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[]
            {settingsButton, homeButton, addFoodCategoryButton, foodCategoryButton});
            ButtonColor.SetButtonColorActive(addFoodButton);
            LoadControl(new AddFoodControl());
        }

        private void AddFoodCategoryButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[]
            {settingsButton, addFoodButton, homeButton, foodCategoryButton});
            ButtonColor.SetButtonColorActive(addFoodCategoryButton);

            LoadControl(new AddCategoryControl());
        }

        private void FoodCategoryButton_Click(object sender, EventArgs e)
        {
            ButtonColor.SetButtonColorDefault(new Button[]
            {settingsButton, addFoodButton, addFoodCategoryButton, homeButton});
            ButtonColor.SetButtonColorActive(foodCategoryButton);

            LoadControl(new CategoryFoodControl());
        }

        private void GeneralForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void GeneralForm_Load(object sender, EventArgs e)
        {

        }
    }
}
