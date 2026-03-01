namespace A_EstrellaV2
{
    public partial class UIAlgoritmo : Form
    {
        public UIAlgoritmo()
        {
            InitializeComponent();
            // Coordenadas X, Y iniciales (a - Actual) y finales (m - Meta)
            int xA, xM, yA, yM; 
            xA = yA = 0;
            xM = yM = 4;
            
            lbResponse.Text = ForAtoM([xA, yA], [xM, yM]);
        }
        private string ForAtoM(int[] actual, int[] meta)
        {
            string res = "";
            for (int y = actual[1]; y < meta[1]; y++)
            {
                res += actual[0] + " " + y + "\n";
            }
            for (int x = actual[0]; x <= meta[0]; x++)
            {
                res += x + " " + meta[1] + "\n";
            }
            return res;
        }
    }
}
