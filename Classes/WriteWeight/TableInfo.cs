using KompasAPI7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Classes.WriteWeight
{
    internal class TableInfo
    {
        private ITable table;
        private int columnWeight;
        public ITable Table { get => table; set => table = value; }
        public int ColumnWeight { get => columnWeight; set => columnWeight = value; }
        public TableInfo(ITable _table, int _columWeight)
        {
            table = _table;
            columnWeight = _columWeight;
        }
    }
}
