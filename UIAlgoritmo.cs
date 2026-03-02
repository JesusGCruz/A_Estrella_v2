using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace A_EstrellaV2
{
    public partial class UIAlgoritmo : Form
    {
        private int ordenClic = 0;

        public UIAlgoritmo()
        {
            InitializeComponent();
            ConfigurarTablero();

            if (btnReiniciar != null) btnReiniciar.Click += btnReiniciar_Click;
            if (btnPlay != null) btnPlay.Click += btnInicio_Click;
        }

        private void ConfigurarTablero()
        {
            for (int i = 1; i <= 25; i++)
            {
                Control[] controles = this.Controls.Find("btn" + i, true);
                if (controles.Length > 0 && controles[0] is Button btn)
                {
                    btn.BackgroundImage = null;
                    btn.BackColor = Color.White;
                    btn.Tag = "Vacio";
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Click += BotonTablero_Click;
                }
            }
        }

        private void BotonTablero_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (ordenClic == 0)
            {
                btn.BackgroundImage = Properties.Resources.inicio;
                btn.Tag = "Inicio";
                ordenClic = 1;
            }
            else if (ordenClic == 1)
            {
                if (btn.Tag.ToString() == "Inicio") return;
                btn.BackgroundImage = Properties.Resources.fin;
                btn.Tag = "Fin";
                ordenClic = 2;
            }
            else
            {
                if (btn.Tag.ToString() == "Inicio" || btn.Tag.ToString() == "Fin") return;
                if (btn.Tag.ToString() == "Vacio")
                {
                    btn.BackgroundImage = Properties.Resources.bombas;
                    btn.Tag = "Bomba";
                }
                else
                {
                    btn.BackgroundImage = null;
                    btn.Tag = "Vacio";
                }
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            int xActual = 0, yActual = 0, xMeta = 0, yMeta = 0;
            List<PointXY> obstaculos = new List<PointXY>();

            for (int i = 1; i <= 25; i++)
            {
                Control[] c = this.Controls.Find("btn" + i, true);
                if (c.Length > 0 && c[0] is Button btn)
                {
                    if (btn.Tag.ToString() == "Inicio") { xActual = (i - 1) % 5; yActual = (i - 1) / 5; }
                    if (btn.Tag.ToString() == "Fin") { xMeta = (i - 1) % 5; yMeta = (i - 1) / 5; }
                    if (btn.Tag.ToString() == "Bomb")// Extraemos las coordenadas de los obstáculos
                    {
                        //obs.Add(new PointXY((i - 1) % 5, (i - 1) / 5));
                    }
                    if (btn.BackColor == Color.Green) btn.BackColor = Color.White;
                }
            }

            //* RECORRIDO
            obstaculos.Add(new PointXY(0, 3)); // Obstáculos hardcodeados temporalmente, espero
            PintarRecorrido(xActual, yActual, xMeta, yMeta, obstaculos);
        }

        private void PintarRecorrido(int xA, int yA, int xM, int yM, List<PointXY> obstaculos)
        {
            // Mandamos a traer al algoritmo A* para que nos dé las coordenadas del recorrido
            List<List<int>> recorrido = AEstrella.ForAtoM(xA, yA, xM, yM, obstaculos);
            // Pintamos las casillas recibidas
            for (int i = 0; i < recorrido[0].Count; i++)
            {
                // En el recorrido, la posición 0 son las X, la posición 1 son las Y
                AplicarColor(recorrido[0][i], recorrido[1][i]);
            }
        }

        private void AplicarColor(int x, int y)
        {
            int id = (y * 5) + x + 1;
            Control[] c = this.Controls.Find("btn" + id, true);
            if (c.Length > 0 && c[0] is Button btn)
            {
                // Solo pintamos si NO hay una bomba
                if (btn.Tag.ToString() != "Bomba" && btn.Tag.ToString() == "Vacio")
                {
                    btn.BackColor = Color.Green;
                }
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ordenClic = 0;
            ConfigurarTablero();
        }
    }
}