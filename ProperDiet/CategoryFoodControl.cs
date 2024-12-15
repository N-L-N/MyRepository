using Guna.UI2.WinForms;
using ProperDiet.Controls.Blocks;
using ProperDiet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet
{
    public partial class CategoryFoodControl : UserControl
    {
        public CategoryFoodControl()
        {
            InitializeComponent();
        }

        private void CategoryControl_Load(object sender, EventArgs e)
        {
            new ContextBlock(new CategoryBlock(BlocksAdder))
                .CreateBlock();
        }
    }
}
