using ProperDiet.Intefaces.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet.Animation
{
    internal static class AnimPanel
    {
        public static async Task Anim(Panel blockPanel, int duration)
        {
            int targetHeight = blockPanel.Height == 150 ? 50 : 150;
            int steps = 20;
            int stepSize = (targetHeight - blockPanel.Height) / steps;

            for (int i = 0; i < steps; i++)
            {
                blockPanel.Height += stepSize;
                await Task.Delay(duration / steps); // Плавное изменение высоты
            }
        }
    }



}
