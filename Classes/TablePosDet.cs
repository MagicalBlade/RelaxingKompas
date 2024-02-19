using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Classes
{
    internal class TablePosDet
    {
        private ITable table;
        private int indexColumnPos;
        private int indexColumnThickness = -1;
        private int indexColumnSteel = -1;

        /// <summary>
        /// Таблица с данными позиций
        /// </summary>
        public ITable Table { get => table; set => table = value; }
        /// <summary>
        /// Номер столбца с наименовением позиций
        /// </summary>
        public int IndexColumnPos { get => indexColumnPos; set => indexColumnPos = value; }
        /// <summary>
        /// Номер столбца с толщиной
        /// </summary>
        public int IndexColumnThickness { get => indexColumnThickness; set => indexColumnThickness = value; }
        /// <summary>
        /// Номер столбца со сталью
        /// </summary>
        public int IndexColumnSteel { get => indexColumnSteel; set => indexColumnSteel = value; }

        public TablePosDet(ITable _table, int _indexColumnPos)
        {
            Table = _table;
            IndexColumnPos = _indexColumnPos;
        }

    }
}
