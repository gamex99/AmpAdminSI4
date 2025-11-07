using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace SurFeFront
{
    public partial class GraficosAltaClientesMensualesMDI : Form
    {
        public GraficosAltaClientesMensualesMDI()
        {
            InitializeComponent();
            // Crear TabControl
            TabControl tabControl = new TabControl { Dock = DockStyle.Fill };
            this.Controls.Add(tabControl);

            TabPage tabGrafico = new TabPage("Alta Clientes Mensuales");
            tabControl.TabPages.Add(tabGrafico);

            // Crear Chart dentro de la TabPage
           // Chart chartClientes = new Chart { Dock = DockStyle.Fill };
            //tabGrafico.Controls.Add(chartClientes);

            // Generar gráfico
            
        }
    }
}