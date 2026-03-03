using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_EstrellaV2
{
    internal class AEstrella
    {
        public static List<List<int>> ForAtoM(int xA, int yA, int xM, int yM, List<int> xObstaculos, List<int> yObstaculos, Label lblF)
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

            //usare contadores temporales para h(n) ya que se tiene que recalcular la ofrmula cada que avanza
            int tempHn, tempf = 0;
            int cG = 0;
            // cG solo es un incremento cmo un paso por eso aun sgue en 0 en la primera calculacion
            int h = 0; // valor que queda
            tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
            int f = 0; // valor que queda
            tempf = cG + h;


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

                    //if (x == obstaculos[0].x && y + 1 == obstaculos[0].y)
                    int temp = xObstaculos.IndexOf(x);
                    if (temp != -1 && ((y + 1) == yObstaculos[temp]))
                    { //Si hay un obstaculo en el siguiente paso se desvía a la derecha
                        x++;
                        cG++;// Incrementamos el coste del camino real en cualuqier caso
                        tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
                        tempf = cG + h;
                        h =+ tempHn; //se le van sumando los resultados de h(n) cada que se desvía
                        f =+ tempf; // lo mismo pero no se si este correcto por que se supone que la ofrmula es para ir recalculando el camino por donde pasa
                    }
                    else
                    { // Se va para abajo
                        y++;
                        cG++;
                        tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
                        tempf = cG + h;
                        h =+ tempHn; 
                        f =+ tempf;
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
                    //if (x == obstaculos[0].x && y + 1 == obstaculos[0].y)
                    int temp = xObstaculos.IndexOf(x);
                    if (temp != -1 && ((y - 1) == yObstaculos[temp]))
                    { // Se desvia hacia la izquierda en caso de obstaculo
                        x--;
                        cG++;
                        tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
                        tempf = cG + h;
                        h =+ tempHn;
                        f =+ tempf; //el proceso es el mismo pero como es diferente direccion no importa
                    }
                    else
                    { // Vamos para abajo
                        y--;
                        cG++;
                        tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
                        tempf = cG + h;
                        h =+ tempHn;
                        f =+ tempf;
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
                    int temp = xObstaculos.IndexOf(y);
                    if (x == xM || x > 4) break;
                    //else if (x + 1 == obstaculos[0].x && y == obstaculos[0].y)
                    else if (temp != -1 && ((x + 1) == xObstaculos[temp]))
                    {
                        y--;// Se desvía hacia arriba para evitar el obstaculo
                        movY++;// Registramos que se desvió una vez
                        cG++;
                        tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
                        tempf = cG + h;
                        h =+ tempHn;
                        f =+ tempf; //seguny o y mi cerebro confundido hace lo mismo aqui ya que es otro movimiento
                    }
                    else
                    { // Vamos pa la derecha
                        x++;
                        cG++;
                        tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
                        tempf = cG + h;
                        h =+ tempHn;
                        f =+ tempf;
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
                    int temp = xObstaculos.IndexOf(y);
                    if (x == xM || x < 0) break;
                    //else if (x - 1 == obstaculos[0].x && y == obstaculos[0].y)
                    else if (temp != -1 && ((x - 1) == xObstaculos[temp]))
                    {
                        y++;// Desviamos para abajo
                        movY++;
                        cG++;
                        tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
                        tempf = cG + h;
                        h =+ tempHn;
                        f =+ tempf; // lo mismo que arriba
                    }
                    else
                    {
                        x--;// Vamos a la izquierda
                        cG++;
                        tempHn = Math.Abs(x - xM) + Math.Abs(y - yM);
                        tempf = cG + h;
                        h =+ tempHn;
                        f =+ tempf;// teh same
                    }
                }
            }
            if (movY > 0)// Si se desvia al menos una vez -----Aqui ya no entendi asi que aqui no puse la ofmrula
            { // Lo regresamos
                System.Diagnostics.Debug.WriteLine("[" + x + ", " + (y + movY) + "]movY");
                Xs.Add(x);
                Ys.Add(y);
            }
            System.Diagnostics.Debug.WriteLine("---------------------------------------------------------\n");
            recorrido.Add(Xs);
            recorrido.Add(Ys);
            return recorrido;


            //Falta meter la formula (ni idea de que sea f(n) JANE
            //g es el coste del camino en timepo real desde el nodo inicial hasta el nodo n TT
            //f(n) = g(n) + h(n)
            //h(n) = |xActual - xMeta| + |yActual - yMeta|
            //int avance_g = x + 1;
            //int h = Math.Abs(x - xM) + Math.Abs(y - yM);
            //int f = avance_g + h;
            //al final solo se meustra f en la pantalla o todo lo que quedo del calculo auqnue
            //creo que solo deberiamos poner una suma de cuantas veecs se movio asi que mostare
            //ambas y si una no sale oslo mostramos la otra >:(
            lblF.Text = f.ToString();

            
        }
    }
}
