using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ProperDiet.Controls.Static
{
    public static class UiMode
    {
        public static bool IsDarkMode = true;
        private const string key = "UIMode";
        public static event Action OnThemeChanged; // Событие для обновления темы

        public static void Update()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string mode = config.AppSettings.Settings[key]?.Value;

            if (mode == "dark")
            {
                IsDarkMode = true;
            }
            else
            {
                IsDarkMode = false;
                SetMode("light");
            }
        }

        public static void DarkMode()
        {
            if (!IsDarkMode)
            {
                SetMode("dark");
                IsDarkMode = true;
                OnThemeChanged?.Invoke(); // Уведомляем подписчиков
            }
        }

        public static void LightMode()
        {
            if (IsDarkMode)
            {
                SetMode("light");
                IsDarkMode = false;
                OnThemeChanged?.Invoke(); // Уведомляем подписчиков
            }
        }

        private static void SetMode(string mode)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null)
            {
                config.AppSettings.Settings.Add(key, mode);
            }
            else
            {
                config.AppSettings.Settings[key].Value = mode;
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

}
