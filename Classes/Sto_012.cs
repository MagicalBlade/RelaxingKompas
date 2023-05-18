using Kompas6Constants3D;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelaxingKompas.Classes
{
    internal class Sto_012
    {
        /// первое и второе число - диапозон толщин, третье число - значение шероховатости <summary>
        /// первое и второе число - диапозон толщин, третье число - значение шероховатости
        /// </summary>
        private int[][] _roughKat1 = new int[][]
        {
            new int[] { 6, 12, 50 },
            new int[] { 14, 30, 60 },
            new int[] { 32, 60, 70 }
        };
        private int[][] _roughKat2 = new int[][]
        {
            new int[] { 6, 12, 80 },
            new int[] { 14, 30, 160 },
            new int[] { 32, 60, 250 }
        };
        private int[][] _roughKat3 = new int[][]
        {
            new int[] { 6, 12, 160 },
            new int[] { 14, 30, 250 },
            new int[] { 32, 60, 320 }
        };

        public Sto_012(int[][] roughKat1, int[][] roughKat2, int[][] roughKat3)
        {
            RoughKat1 = roughKat1;
            RoughKat2 = roughKat2;
            RoughKat3 = roughKat3;
        }

        /// <summary>
        /// Шеровоатость по 1 категории
        /// </summary>
        [JsonProperty("Первый класс шероховатости")]
        public int[][] RoughKat1 { get => _roughKat1; set => _roughKat1 = value; }
        /// <summary>
        /// Шеровоатость по 2 категории
        /// </summary>
        [JsonProperty("Второй класс шероховатости")]
        public int[][] RoughKat2 { get => _roughKat2; set => _roughKat2 = value; }
        /// <summary>
        /// Шеровоатость по 3 категории
        /// </summary>
        [JsonProperty("Третий класс шероховатости")]
        public int[][] RoughKat3 { get => _roughKat3; set => _roughKat3 = value; }

        public int GetRough(int selectkat, int thickness)
        {
            int[][] roughKat;
            switch (selectkat)
            {
                case 1:
                    roughKat = RoughKat1;
                    break;
                case 2:
                    roughKat = RoughKat2;
                    break;
                case 3:
                    roughKat = RoughKat3;
                    break;
                default:
                    return 0;
            }
            foreach (var kat in roughKat)
            {
                if (thickness >= kat[0] && thickness <= kat[1])
                {
                    return kat[2]; 
                }
            }
            return 0;
        }
    }
}
