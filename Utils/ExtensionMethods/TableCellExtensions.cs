using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Utils.ExtensionMethods
{
    public static class TableCellExtensions
    {
        /// <summary>
        /// Получение строки из TableCell
        /// </summary>
        /// <param name="tableCell"></param>
        /// <returns></returns>
        public static string GetStr(this ITableCell tableCell)
        {
            return ((IText)tableCell.Text).Str;
        }
    }
}
