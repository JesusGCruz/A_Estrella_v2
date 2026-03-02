using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_EstrellaV2
{
    internal class AEstrella
    {
        public static List<List<int>> ForAtoM(int xA, int yA, int xM, int yM, List<PointXY> obstaculos)
        {
            //System.Diagnostics.Debug.WriteLine("ent: " + xA + " " + yA + " " + xM + " " + yM);
            //PointXY actual = new PointXY(0, 0);
            //PointXY meta = new PointXY(0, 4);
            List<List<int>> recorrido = new List<List<int>>();
            List<int> Xs = new List<int>();
            List<int> Ys = new List<int>();
            System.Diagnostics.Debug.WriteLine("\n---------------------------------------------------------");

            int x = xA;
            int y = yA;
            if (yA < yM)
            {// 1.- Si Yactual es menor que Ymeta; se sigue con normalidad
                while (true)
                {
                    // El ciclo se ejecuta  hasta que Y llega  o pasa la meta
                    if (y == yM || y > 4) break; // Rompiendo el bucle omitiendo todo lo demás 
                    // Omitimos la ultima iteración ya que tambien la muestra X
                    System.Diagnostics.Debug.WriteLine("[" + x + ", " + y + "]y");
                    Xs.Add(x);
                    Ys.Add(y);

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
                    if (y == yM || y < 0) break;
                    System.Diagnostics.Debug.WriteLine("[" + x + ", " + y + "]y-");
                    Xs.Add(x);
                    Ys.Add(y);
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
            if (x < xM)
            {// Lo mismo de 1.- pero con X
                while (true)
                {
                    System.Diagnostics.Debug.WriteLine("[" + x + ", " + y + "]x");
                    Xs.Add(x);
                    Ys.Add(y);
                    if (x == xM || x > 4) break;
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
                    Xs.Add(x);
                    Ys.Add(y);
                    if (x == xM || x < 0) break;
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
                Xs.Add(x);
                Ys.Add(y);
            }
            System.Diagnostics.Debug.WriteLine("---------------------------------------------------------\n");
            recorrido.Add(Xs);
            recorrido.Add(Ys);
            return recorrido;
            //Falta meter la formula (ni idea de que sea f(n)
        }
    }
}
