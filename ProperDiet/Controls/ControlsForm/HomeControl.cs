﻿using ProperDiet.Animation;
using ProperDiet.Controls.Blocks;
using ProperDiet.Controls.Static;
using ProperDiet.Entity;
using ProperDiet.Intefaces.Animation;
using ProperDiet.Intefaces.Blocks;
using ProperDiet.Models.Entity;
using ProperDiet.Services;
using ProperDiet.Services.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();

            UiMode.Update();

            ApplyTheme();

            UiMode.OnThemeChanged += ApplyTheme;
        }

        private User user;
        private TxtDbContext _txtDbContext;
        
        public HomeControl(User user)
        {
            InitializeComponent();

            this.user = user;

            _txtDbContext = new TxtDbContext();

            new ContextBlock(new MealEntryBlock(mealEntryPanel, user.Id, _txtDbContext)).CreateBlock();
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

        private void HomeControl_Load(object sender, EventArgs e)
        {
            
        }

        private void InfoDietButton_Click(object sender, EventArgs e)
        {
            
        }

        private void infoPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void UpdateButtonPosition(Button button, Panel panel)
        {
            button.Location = new Point(
                panel.Width - button.Width - panel.Padding.Right,
                panel.Padding.Top
            );
        }
        private void UpdateLabelRightPosition(Label label, Panel panel)
        {
            label.Location = new Point(
                panel.Width - label.Width - panel.Padding.Right, // Расположить по правому краю с учётом отступа
                panel.Height - label.Height - panel.Padding.Bottom // Расположить по нижнему краю с учётом отступа
            );
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
           
        }

        private void InfoPanel_SizeChanged(object sender, EventArgs e)
        {
            
        }
    }
}
