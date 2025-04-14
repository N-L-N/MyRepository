using ProperDiet.Animation;
using ProperDiet.Controls.Static;
using ProperDiet.Models.Entity;
using ProperDiet.Properties;
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
using System.Web.Configuration;
using System.Windows.Forms;


namespace ProperDiet
{
    public partial class GeneralForm : Form
    {
        public GeneralForm()
        {
            InitializeComponent();
            Init(); // Вызываем метод инициализации
        }

        private readonly User _user;
        private Human _human;
        private CalculatorCalories calculator;
        private TxtDbContext _txtDbContext;

        private DateTime _lastNotificationTime = DateTime.MinValue;

        private Bitmap[] imagesWhite;
        private Bitmap[] imagesBlack;

        public GeneralForm(User user, Human human)
        {
            InitializeComponent();
            InitializeBitmapResources();

            _user = user;
            _human = human;
            calculator = new CalculatorCalories(_human);
            _txtDbContext = new TxtDbContext();

            NameUser.Text = _user.Name;

            Init(); // Вызываем метод инициализации
        }

        private void Init()
        {
            ApplyTheme(); // Устанавливаем тему при старте
            UiMode.OnThemeChanged += ApplyTheme; // Подписываемся на изменение темы

            ButtonsSettings.SetButtonColorDefault(GetAllButtons(this)); // Устанавливаем цвета кнопок
            CalculateCalories(); // Сразу считаем калории
        }

        private void InitializeBitmapResources()
        {
            imagesBlack = new Bitmap[]
            {
                Resources.home_black,
                Resources.settings_black,
                Resources.food_black,
                Resources.add_black,
                Resources.category_black,
                Resources.help_black,
            };

            imagesWhite = new Bitmap[]
            {
                Resources.home_white,
                Resources.settings_white,
                Resources.food_white,
                Resources.add_white,
                Resources.category_white,
                Resources.help_white,
            };
        }

        private void ApplyTheme()
        {
            this.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
            this.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;

            menuButton.BackgroundImage = UiMode.IsDarkMode ? Resources.burger_white : Resources.burger_black;

            foreach (Control control in this.Controls)
            {
                ApplyThemeToControl(control);
            }

            ActiveImageButton(GetAllButtons(this), imagesWhite, imagesBlack);

            foreach (var buttons in GetAllButtons(this))
            {
                if (ButtonsSettings.activeButton == buttons)
                {
                    ButtonsSettings.SetButtonColorActive(buttons);
                    return;
                }
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

        private void CalculateCalories()
        {
            var mealEntries = _txtDbContext.GetMealEntriesByUserIdAndByDateTime(_user.Id, DateTime.Now);
            int maxCaloriesNumber = calculator.Calories;
            int totalCalories = 0;
            var groupedEntries = mealEntries.GroupBy(entry => entry.Date.Date);
            foreach (var group in groupedEntries)
            {
                var foodDetails = group
                    .Select(entry =>
                    {
                        var food = _txtDbContext.GetFoodById(entry.FoodId);
                        if (food != null)
                        {
                            // Учитываем размер порции для расчета калорий  
                            int calories = (food.Calories * entry.PortionSize) / 100;
                            return (Name: food.Name, Description: food.Description, Calories: calories);
                        }
                        return (Name: (string)null, Description: (string)null, Calories: 0);
                    })
                    .Where(fd => fd.Name != null)
                    .ToList();
                if (foodDetails.Count > 0)
                {
                    totalCalories = foodDetails.Sum(fd => fd.Calories);
                }

                if (maxCaloriesNumber < totalCalories)
                {
                    ShowNotification("⚠️ Превышение калорий", $"Вы превысили лимит на {totalCalories - maxCaloriesNumber} ккал!");
                    maxCalories.Text = $"Лимит превышен на {Math.Abs(maxCaloriesNumber - totalCalories)} кл";
                }
                else
                    maxCalories.Text = $"Осталось съесть: {maxCaloriesNumber - totalCalories} кл";
            }
        }
        private void ShowNotification(string title, string message)
        {
            calorieNotifyIcon.Icon = SystemIcons.Warning; 
            calorieNotifyIcon.BalloonTipTitle = title;
            calorieNotifyIcon.BalloonTipText = message;
            calorieNotifyIcon.BalloonTipIcon = ToolTipIcon.Warning;

            if ((DateTime.Now - _lastNotificationTime).TotalMinutes > 10) // Пример: не чаще 1 раза в 10 минут
            {
                calorieNotifyIcon.ShowBalloonTip(5000);
                _lastNotificationTime = DateTime.Now;
            }
        }
        private async void MenuButton_Click(object sender, EventArgs e)
        {
            await AnimPanel.AnimateFlowPanelWidth(sidebarContainer, 1, sidebarContainer.MaximumSize.Width, sidebarContainer.MinimumSize.Width);

            await AnimPanel.AnimatePanelHeight(menuPanel, 1, menuPanel.MaximumSize.Height, menuPanel.MinimumSize.Height);

            if (sidebarContainer.Width == sidebarContainer.MinimumSize.Width)
            {
                NameUser.Visible = false;
                maxCalories.Visible = false;
            }
            else
            {
                NameUser.Visible = true;
                maxCalories.Visible = true;
            }
        }

        private void LoadControl(UserControl control)
        {
            PagePanel.Controls.Clear();
            PagePanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            CalculateCalories();
        }

        private void ActiveImageButton(Button[] buttons, Bitmap[] imageWhite, Bitmap[] imageBlack)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (ButtonsSettings.activeButton == buttons[i])
                {
                    buttons[i].Image = UiMode.IsDarkMode ? imageBlack[i] : imageWhite[i];
                }
                else
                {
                    buttons[i].Image = UiMode.IsDarkMode ? imageWhite[i] : imageBlack[i];
                }
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            ButtonsSettings.SetButtonColorDefault(GetAllButtons(this));
            ButtonsSettings.SetButtonColorActive(homeButton);

            ActiveImageButton(GetAllButtons(this), imagesWhite, imagesBlack);

            LoadControl(new HomeControl(_user));
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ButtonsSettings.SetButtonColorDefault(GetAllButtons(this));
            ButtonsSettings.SetButtonColorActive(settingsButton);

            ActiveImageButton(GetAllButtons(this), imagesWhite, imagesBlack);

            LoadControl(new Settings());
        }
        private void FoodCategoryButton_Click(object sender, EventArgs e)
        {
            ButtonsSettings.SetButtonColorDefault(GetAllButtons(this));
            ButtonsSettings.SetButtonColorActive(foodCategoryButton);

            ActiveImageButton(GetAllButtons(this), imagesWhite, imagesBlack);

            LoadControl(new CategoryFoodControl());
        }

        private void GeneralForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void GeneralForm_Load(object sender, EventArgs e)
        {
            Init(); // Грузим всё при старте
        }

        private Button[] GetAllButtons(Control parent)
        {
            return parent.Controls
                         .OfType<Button>()
                         .Concat(parent.Controls.OfType<Panel>()
                         .SelectMany(GetAllButtons))
                         .Concat(parent.Controls.OfType<GroupBox>()
                         .SelectMany(GetAllButtons))
                         .ToArray();
        }

        private IEnumerable<Button> GetAllButtons(Panel panel)
        {
            return panel.Controls.OfType<Button>()
                  .Concat(panel.Controls.OfType<Panel>()
                  .SelectMany(GetAllButtons));
        }

        private IEnumerable<Button> GetAllButtons(GroupBox groupBox)
        {
            return groupBox.Controls.OfType<Button>()
                  .Concat(groupBox.Controls.OfType<Panel>()
                  .SelectMany(GetAllButtons));
        }

        private void PagePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maxCalories_Click(object sender, EventArgs e)
        {

        }
    }
}
