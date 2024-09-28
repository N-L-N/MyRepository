using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet.Static
{
    static public class ButtonColor
    {
        private static Color defaultColorButton = Color.FromArgb(28, 27, 50);

        private static Color activeColorButton = Color.FromArgb(28, 27, 80);
        public static void SetButtonColor(Button button, Color color)
        {
            button.BackColor = color;
        }
        public static void SetButtonColorDefault(Button button)
        {
            button.BackColor = defaultColorButton;
        }
        public static void SetButtonColorDefault(Button[] button)
        {
            foreach (var item in button)
            {
                item.BackColor = defaultColorButton;
            }
        }
        public static void SetButtonColorActive(Button button)
        {
            button.BackColor = activeColorButton;
        }
        public static void SetButtonColorActive(Button[] button)
        {
            foreach (var item in button)
            {
                item.BackColor = activeColorButton;
            }
        }
    }
}
