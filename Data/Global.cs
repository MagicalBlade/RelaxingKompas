using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Data
{
    internal class Global
    {
        /// <summary>
        /// Хранение списка ивентов на которые подписался
        /// </summary>
        private static ArrayList eventList = new ArrayList();
        public static ArrayList EventList
        {
            get
            {
                return eventList;
            }
            set
            {
                eventList = value;
            }
        }
    }
}
