using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Data.Global
{
    internal static class Global_ArcDimension
    {
        /// <summary>
        /// Счетчик количество кликов произведенных пользователем
        /// </summary>
        public static int CountClick = 0;
        public static double X1;
        public static double X2;
        public static double Y1;
        public static double Y2;
        public static double Xc, Yc;
        public static IArc arc = null;
    }
}
