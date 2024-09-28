using ProperDiet.Intefaces.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet.Static
{
    public class AnimFlowLayotPanel : IAnimElement
    {
        private FlowLayoutPanel _sidebarContainer;
        private int _speedAnimation;
        private bool _sidebarExpand = false;
        private bool _isAnimating = false;
        public AnimFlowLayotPanel(FlowLayoutPanel sidebarContainer, int speedAnimation)
        {
            _sidebarContainer = sidebarContainer;

            _speedAnimation = speedAnimation;
        }

        public async Task Anim()
        {
            if (_isAnimating) return; // Если анимация уже запущена, выходим
            _isAnimating = true;

            while (_isAnimating)
            {
                if (_sidebarExpand)
                {
                    _sidebarContainer.Width -= _speedAnimation;

                    if (_sidebarContainer.Width <= _sidebarContainer.MinimumSize.Width)
                    {
                        _sidebarContainer.Width = _sidebarContainer.MinimumSize.Width;
                        _sidebarExpand = false;
                        _isAnimating = false;  // Останавливаем анимацию
                    }
                }
                else
                {
                    _sidebarContainer.Width += _speedAnimation;

                    if (_sidebarContainer.Width >= _sidebarContainer.MaximumSize.Width)
                    {
                        _sidebarContainer.Width = _sidebarContainer.MaximumSize.Width;
                        _sidebarExpand = true;
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
