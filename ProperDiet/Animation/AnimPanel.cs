using ProperDiet.Intefaces.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet.Animation
{
    internal class AnimPanel : IAnimElement
    {
        private Panel _infoPanel;
        private readonly int _speedAnimation;
        private bool _infoExpand = false;
        private bool _isAnimating = false;
        public AnimPanel(Panel infoPanel, int speedAnimation) 
        {
            _speedAnimation = speedAnimation;

            _infoPanel = infoPanel;
        }
        public async Task Anim()
        {
            if (_isAnimating) return; // Если анимация уже запущена, выходим
            _isAnimating = true;

            while (_isAnimating)
            {
                if (_infoExpand)
                {
                    _infoPanel.Height -= _speedAnimation;

                    if (_infoPanel.Height <= _infoPanel.MinimumSize.Height)
                    {
                        _infoPanel.Height = _infoPanel.MinimumSize.Height;
                        _infoExpand = false;
                        _isAnimating = false;  // Останавливаем анимацию
                    }
                }
                else
                {
                    _infoPanel.Height += _speedAnimation;

                    if (_infoPanel.Height >= _infoPanel.MaximumSize.Height)
                    {
                        _infoPanel.Height = _infoPanel.MaximumSize.Height;
                        _infoExpand = true;
                        _isAnimating = false;  // Останавливаем анимацию
                    }
                }

                await Task.Delay(1);
            }
        }
        public void StopAnim()
        {
            _isAnimating = false;
        }
    }
}
