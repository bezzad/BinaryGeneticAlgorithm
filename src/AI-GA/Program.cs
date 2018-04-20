// this program created by Mr. Behzad Khosravifar in Date "10 dec(12) 2009"
// for lesson Artificial Intelligence
// 
//    Binary Genetic Algorithm for find minimum fitness F1(x) = |x| + Cos(x)
//    Class Program (for run form in c# project)
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AI_BGA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBGA());
        }
    }
}
