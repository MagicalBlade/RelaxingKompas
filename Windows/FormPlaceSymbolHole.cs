using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelaxingKompas.Windows
{
    public partial class FormPlaceSymbolHole : Form
    {
        public string typeElement = "circle";

        public FormPlaceSymbolHole()
        {
            InitializeComponent();
        }

        private void b_circle_Click(object sender, EventArgs e)
        {
            typeElement = "circle";
        }

        private void b_center_Click(object sender, EventArgs e)
        {
            typeElement = "center";

        }
    }
}
