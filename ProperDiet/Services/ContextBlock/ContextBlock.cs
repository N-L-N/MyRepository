using ProperDiet.Intefaces.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProperDiet.Services
{
    internal class ContextBlock
    {
        public IBlock Block { private get; set; }

        public ContextBlock(IBlock block) 
        {
            Block = block;
        }

        public void CreateBlock()
        {
            Block.CreateBlockAsync();
        }
    }
}
