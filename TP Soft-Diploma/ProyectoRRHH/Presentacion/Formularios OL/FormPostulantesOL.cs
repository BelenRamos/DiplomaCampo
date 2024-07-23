using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Formularios_OL
{
    public partial class FormPostulantesOL : Form
    {
        public FormPostulantesOL()
        {
            InitializeComponent();
        }

        public FormPostulantesOL(int numero)
        {
            Numero = numero;
        }

        public int Numero { get; }

        private void FormPostulantesOL_Load(object sender, EventArgs e)
        {
            //OL_Postulantes
        }
    }
}
