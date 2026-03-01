using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_EstrellaV2
{
    internal class AEstrella
    {
        public static void ForAtoM()
        {
            int[] actual = [0, 0];
            int[] meta = [4, 4];
            string res = "";
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
        }
    }
}
