using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_EstrellaV2
{
    internal class AEstrella
    {
        public class PointXY
        {
            public int x { get; set; }
            public int y { get; set; }

            public PointXY(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public static void ForAtoM()
        {
            PointXY actual = new PointXY(0, 0);
            PointXY meta = new PointXY(0, 4);
            PointXY[] obstaculos = [
                new PointXY(0, 2),
                new PointXY(4, 2)
                ];
            System.Diagnostics.Debug.WriteLine("\n---------------------------------------------------------\n");

            int x = actual.x;
            int y = actual.y;
            while (y < meta.y)
            {
                System.Diagnostics.Debug.WriteLine("1.- " + x + " " + y + "\n");
                if (x == obstaculos[0].x && y + 1 == obstaculos[0].y)
                {
                    x++;
                }
                else
                {
                    y++;
                }
            }

            if (x < meta.x)
            {// Lo mismo de arriba pero con X
                while (x <= meta.x)
                {
                    System.Diagnostics.Debug.WriteLine("2.- " + x + " " + y + "\n");
                    x++;
                }
            }
            else
            {
                while (x >= meta.x)
                {
                    System.Diagnostics.Debug.WriteLine("2.- " + x + " " + y + "\n");
                    x--;
                }
            }

            /*
            int[] actual = [0, 0];
            int[] meta = [4, 4];
            string res = "\n---------------------------------------------------------\n";
            // Primero nos vamos en Y
            int y = actual[1];
            if (actual[1] < meta[1])
            {// Si Yactual es menor que Ymeta; se sigue con normalidad
                while (y < meta[1])
                {
                    res += actual[0] + " " + y + "\n";
                    y++;
                }
            }
            else
            {// Si Yactual es mayor que Ymeta; se va pa atrás
                while (y > meta[1])
                {
                    res += actual[0] + " " + y + "\n";
                    y--;
                }
            }

            // Luego nos vamos en X
            int x = actual[0];
            if (actual[0] < meta[0])
            {// Lo mismo de arriba pero con X
                while (x <= meta[0])
                {
                    res += x + " " + meta[1] + "\n";
                    x++;
                }
            }
            else
            {
                while (x >= meta[0])
                {
                    res += x + " " + meta[1] + "\n";
                    x--;
                }
            }
            System.Diagnostics.Debug.WriteLine(res);
             */
        }
    }
}
