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
        public static async Task AnimatePanelHeight(Panel blockPanel, int duration, int maxHeight, int minHeight)
        {
            int targetHeight = blockPanel.Height == maxHeight ? minHeight : maxHeight;
            int steps = 20;
            int stepSize = (targetHeight - blockPanel.Height) / steps;

            for (int i = 0; i < steps; i++)
            {
                blockPanel.Height += stepSize;
                await Task.Delay(duration / steps); 
            }

           
            blockPanel.Height = targetHeight;
        }

        public static async Task AnimateFlowPanelWidth(FlowLayoutPanel blockPanel, int duration, int maxWidth, int minWidth)
        {
            int targetWidth = blockPanel.Width == maxWidth ? minWidth : maxWidth;
            int steps = 20;
            int stepSize = (targetWidth - blockPanel.Width) / steps;
            for (int i = 0; i < steps; i++)
            {
                blockPanel.Width += stepSize;
                await Task.Delay(duration / steps); 
            }
            
            blockPanel.Width = targetWidth;
        }
    }



}
