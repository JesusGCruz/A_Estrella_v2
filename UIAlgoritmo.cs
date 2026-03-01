namespace A_EstrellaV2
{
    public partial class UIAlgoritmo : Form
    {
        public UIAlgoritmo()
        {
            InitializeComponent();
            // Coordenadas X, Y iniciales (a - Actual) y finales (m - Meta)
            int xA, xM, yA, yM;
            xA = yA = 4;
            xM = yM = 0;

            lbResponse.Text = ForAtoM([xA, yA], [xM, yM]);
        }
        private string ForAtoM(int[] actual, int[] meta)
        {
            string res = "";
            int x = actual[0];
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
                /*
                for (int y = actual[1]; y < meta[1]; y++)
                {
                    res += actual[0] + " " + y + "\n";
                }
                for (int x = actual[0]; x <= meta[0]; x++)
                {
                    res += x + " " + meta[1] + "\n";
                }
                 */
                return res;
        }
    }
}
