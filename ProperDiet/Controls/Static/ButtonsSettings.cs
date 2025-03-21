using ProperDiet.Controls.Static;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet.Static
{
    public static class ButtonsSettings
    {
        private static Button[] buttons = Array.Empty<Button>();
        public static Button activeButton = null; // Храним активную кнопку

        static ButtonsSettings()
        {
            UiMode.OnThemeChanged += UpdateButtons;
        }

        public static void SetButtonColorDefault(Button[] newButtons)
        {
            buttons = newButtons;
            UpdateButtons();
        }

        public static void SetButtonColorActive(Button button)
        {
            if (activeButton != null)
            {
                // Возвращаем предыдущую активную кнопку в дефолтный стиль
                activeButton.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
                activeButton.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
            }

            // Устанавливаем стиль для новой активной кнопки
            button.BackColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
            button.ForeColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
            activeButton = button;
        }

        private static void UpdateButtons()
        {
            if (buttons == null || buttons.Length == 0) return;

            foreach (var button in buttons)
            {
                if (button == activeButton)
                {
                    // Активная кнопка остаётся подсвеченной даже после смены темы
                    button.BackColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
                    button.ForeColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
                }
                else
                {
                    // Обычные кнопки перекрашиваются в стандартные цвета темы
                    button.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
                    button.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
                }
            }
        }
    }

}
