﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDiet.Intefaces.Animation
{
    public interface IAnimElement
    {
        Task Anim();
        void StopAnim();
    }
}
