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
            
            AEstrella.ForAtoM();

            

            int xActual = 0, yActual = 0, xMeta = 0, yMeta = 0;

            for (int i = 1; i <= 25; i++)
            {
                Control[] c = this.Controls.Find("btn" + i, true);
                if (c.Length > 0 && c[0] is Button btn)
                {
                    if (btn.Tag.ToString() == "Inicio") { xActual = (i - 1) % 5; yActual = (i - 1) / 5; }
                    if (btn.Tag.ToString() == "Fin") { xMeta = (i - 1) % 5; yMeta = (i - 1) / 5; }
                    if (btn.BackColor == Color.Green) btn.BackColor = Color.White;
                }
            }

           //* RECORRIDO
            PintarRecorrido(xActual, yActual, xMeta, yMeta);
        }

        private void PintarRecorrido(int xA, int yA, int xM, int yM)
        {
            int x = xA;
            int y = yA;

            
            if (yA < yM) { while (y < yM) { AplicarColor(x, y); y++; } }
            else { while (y > yM) { AplicarColor(x, y); y--; } }

            // Luego en X
            if (xA < xM) { while (x <= xM) { AplicarColor(x, yM); x++; } }
            else { while (x >= xM) { AplicarColor(x, yM); x--; } }
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