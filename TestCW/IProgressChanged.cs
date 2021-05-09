﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCW
{
    /// <summary>
    /// Интерфейс поддержки индикатора прогресса
    /// </summary>
    public interface IProgressChanged
    {
        void ChangeProgress(int val);
    }
}
