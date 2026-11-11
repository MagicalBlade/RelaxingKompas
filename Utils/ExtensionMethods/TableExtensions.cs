using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Utils.ExtensionMethods
{
    static internal class TableExtensions
    {
        /// <summary>
        /// Возвращает ячейку содержащую str
        /// </summary>
        /// <param name="table"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ITableCell FindCell(this ITable table, string[] str)
        {
            for (int row = 0; row < table.RowsCount; row++)
            {
                for (int column = 0; column < table.ColumnsCount; column++)
                {
                    foreach (string item in str)
                    {
                        if (table.Cell[row, column].GetStr().IndexOf(item, StringComparison.CurrentCultureIgnoreCase) != -1)
                        {
                            return table.Cell[row, column];
                        }
                    }
                }
            }
            return null;
        }
    }
}
