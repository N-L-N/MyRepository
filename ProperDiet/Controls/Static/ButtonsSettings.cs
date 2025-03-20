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
    public class ButtonsSettings
    {
        public void SetButtonColorDefault(Button[] buttons)
        {
            foreach (var button in buttons)
            {
                button.BackColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
                button.ForeColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
            }
        }

        public void SetButtonColorActive(Button button)
        {
            button.BackColor = UiMode.IsDarkMode ? Color.Black : Color.Snow;
            button.ForeColor = UiMode.IsDarkMode ? Color.Snow : Color.Black;
        }
    }

}
