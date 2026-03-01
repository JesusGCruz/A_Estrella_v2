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
            PointXY meta = new PointXY(3, 1);
            PointXY[] obstaculos = [ //Falta ver como comparar varios puntos
                new PointXY(0, 2)
                ];
            System.Diagnostics.Debug.WriteLine("\n---------------------------------------------------------");

            int x = actual.x;
            int y = actual.y;
            if (actual.y < meta.y)
            {// 1.- Si Yactual es menor que Ymeta; se sigue con normalidad
                while (true)
                {
                    // El ciclo se ejecuta  hasta que Y llega  o pasa la meta
                    if (y == meta.y) break; // Rompiendo el bucle omitiendo todo lo demás 
                    // Omitimos la ultima iteración ya que tambien la muestra X
                    System.Diagnostics.Debug.WriteLine("[" + x + ", " + y + "]y");

                    if (x == obstaculos[0].x && y + 1 == obstaculos[0].y)
                    { //Si hay un obstaculo en el siguiente paso se desvía a la derecha
                        x++;
                    }
                    else
                    { // Se va para abajo
                        y++;
                    }
                }
            }
            else
            {// Si Yactual es mayor que Ymeta; se va pa atrás
                while (true)
                {
                    // Al ir para atrás, lo rompe cuando Y sea igual o menor a la meta
                    if (y == meta.y) break;
                    System.Diagnostics.Debug.WriteLine("[" + x + ", " + y + "]y-");
                    if (x == obstaculos[0].x && y + 1 == obstaculos[0].y)
                    { // Se desvia hacia la izquierda en caso de obstaculo
                        x--;
                    }
                    else
                    { // Vamos para abajo
                        y--;
                    }
                }
            }// Terminamos el recorrido de Y evitando obstaculos

            // Al ya haber concluido el recorrido de Y, debemos contar cuantas casillas se desvía
            int movY = 0; // Para al final regresarlo esas casillas
            if (x < meta.x)
            {// Lo mismo de 1.- pero con X
                while (true)
                {
                    System.Diagnostics.Debug.WriteLine("[" + x + ", " + y + "]x");
                    if (x == meta.x) break;
                    else if (x + 1 == obstaculos[0].x && y == obstaculos[0].y)
                    {
                        y--;// Se desvía hacia arriba para evitar el obstaculo
                        movY++;// Registramos que se desvió una vez
                    }
                    else
                    { // Vamos pa la derecha
                        x++;
                    }
                }
            }
            else
            {
                while (true) // -x
                {
                    System.Diagnostics.Debug.WriteLine("[" + x + ", " + y + "]x-");
                    if (x == meta.x) break;
                    else if (x - 1 == obstaculos[0].x && y == obstaculos[0].y)
                    {
                        y++;// Desviamos para abajo
                        movY++;
                    }
                    else
                    {
                        x--;// Vamos a la izquierda
                    }
                }
            }
            if (movY > 0)// Si se desvia al menos una vez
            { // Lo regresamos
                System.Diagnostics.Debug.WriteLine("[" + x + ", " + (y + movY) + "]movY");
            }

            //Falta meter la formula (ni idea de que sea f(n)
            System.Diagnostics.Debug.WriteLine("---------------------------------------------------------\n");
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
