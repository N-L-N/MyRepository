using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sara_UI_Design;
using Sara_UI_Design.SaraControls;

namespace ProperDiet.Controls.ToggleButton
{
    public class MyToggleButton : SaraUI_ToggleButton
    {
        private readonly Timer animationTimer;
        private int toggleX;
        private int targetX;

        public MyToggleButton()
        {
            this.BackColor = SystemColors.Control;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, false);
            animationTimer = new Timer { Interval = 10 };
            animationTimer.Tick += AnimateToggle;

            if (!DesignMode) // Проверяем, запущен ли дизайнер
                CheckedChanged += (s, e) => StartToggleAnimation();
        }
        private GraphicsPath GetFigurePath()
        {
            int num = Math.Max(Height - 1, 1); // Защита от нуля и отрицательных значений
            int width = Math.Max(Width - num - 2, 1);

            Rectangle rect = new Rectangle(0, 0, num, num);
            Rectangle rect2 = new Rectangle(width, 0, num, num);
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rect, 90f, 180f);
            graphicsPath.AddArc(rect2, 270f, 180f);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            toggleX = Checked ? Width - Height + 1 : 2;
        }

        private void StartToggleAnimation()
        {
            targetX = Checked ? Width - Height + 1 : 2;
            animationTimer.Start();
        }

        private void AnimateToggle(object sender, EventArgs e)
        {
            if (toggleX < targetX)
            {
                toggleX += 3;
                if (toggleX >= targetX)
                {
                    toggleX = targetX;
                    animationTimer.Stop();
                }
            }
            else if (toggleX > targetX)
            {
                toggleX -= 3;
                if (toggleX <= targetX)
                {
                    toggleX = targetX;
                    animationTimer.Stop();
                }
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (Parent == null || pevent.Graphics == null)
                return;

            int radius = Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Проверяем, есть ли у Parent цвет фона, иначе используем стандартный
            pevent.Graphics.Clear(this.Parent?.BackColor ?? SystemColors.Control);

            if (Checked)
            {
                pevent.Graphics.FillPath(new SolidBrush(OnBackColor), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(OnToggleColor), new Rectangle(toggleX, 2, radius, radius));
            }
            else
            {
                pevent.Graphics.FillPath(new SolidBrush(OffBackColor), GetFigurePath());
                pevent.Graphics.FillEllipse(new SolidBrush(OffToggleColor), new Rectangle(toggleX, 2, radius, radius));
            }
        }
    }
}
