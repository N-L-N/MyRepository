using ProperDiet.Controls.Static;
using ProperDiet.Intefaces.Animation;
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
        private IAnimElement animElement;
        private User _user;
        private Human _human;
        private CalculatorCalories calculator;
        private TxtDbContext _txtDbContext;

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
                Resources.help_black
            };

            imagesWhite = new Bitmap[]
            {
                Resources.home_white,
                Resources.settings_white,
                Resources.food_white,
                Resources.add_white,
                Resources.category_white,
                Resources.help_white
            };
        }

        private void ApplyTheme()
        {
            this.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
            this.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;

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

            foreach (var mealEntry in mealEntries)
            {
                var food = _txtDbContext.GetFoodById(mealEntry.FoodId);
                maxCaloriesNumber -= food.Calories;
            }

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

        private void AddFoodButton_Click(object sender, EventArgs e)
        {
            ButtonsSettings.SetButtonColorDefault(GetAllButtons(this));
            ButtonsSettings.SetButtonColorActive(addFoodButton);

            ActiveImageButton(GetAllButtons(this), imagesWhite, imagesBlack);

            LoadControl(new AddFoodControl());
        }

        private void AddFoodCategoryButton_Click(object sender, EventArgs e)
        {
            ButtonsSettings.SetButtonColorDefault(GetAllButtons(this));
            ButtonsSettings.SetButtonColorActive(addFoodCategoryButton);

            ActiveImageButton(GetAllButtons(this), imagesWhite, imagesBlack);

            LoadControl(new AddCategoryControl());
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
    }
}
