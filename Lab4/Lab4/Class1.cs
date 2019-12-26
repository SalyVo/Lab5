using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class levensteinDist
    {
        // Минимум двух переменных
        static int min(int v1, int v2)
        {
            if (v1 < v2) return v1;
            return v2;
        }

        // Минимум трех переменных
        static int min(int v1, int v2, int v3)
        {
            return min(v1, min(v2, v3));
        }

        public static int calcLevenstein(string sx, string sy, bool damerau = false)
        {
            int[,] m;

            return calcLevenstein(sx, sy, out m, damerau);
        }

        public static int calcLevenstein(string sx, string sy, out int[,] m, bool damerau = false )
        {
            m = new int[sx.Length + 1, sy.Length + 1];
            int x, y, d;

            // Начальная инициализация
            m[0, 0] = 0;
            for (x = 1; x <= sx.Length; x++)
                m[x, 0] = x;
            for (y = 1; y <= sy.Length; y++)
                m[0, y] = y;

            // Основной цикл
            for (x = 1; x <= sx.Length; x++)
                for (y = 1; y <= sy.Length; y++)
                {
                    d = (sx[x - 1] == sy[y - 1] ? 0 : 1);

                    m[x, y] = min(
                        m[x - 1, y] + 1,
                        m[x, y - 1] + 1,
                        m[x - 1, y - 1] + d);

                    // Дополнительная проверка на перестановку соседних символов
                    // Условие Дамерау-Левенштейна
                    if ((x > 1) & (y > 1) & damerau)
                        m[x, y] = min(m[x, y], m[x - 2, y - 2] + 1);
                }

            return m[sx.Length, sy.Length];
        }
    }
}
