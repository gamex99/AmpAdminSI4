using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScottPlot.Palettes;

namespace SurFeFront
{
    public partial class GraficoVentasProductosPorCategorias : Form
    {

        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public GraficoVentasProductosPorCategorias()
        {
            InitializeComponent();
            panel1.Controls.Add(FormsPlot1);

            // 1. Llama a la NUEVA función aquí
            CargarGraficoFormasDePago();

            FormsPlot1.Refresh();
        }


        private void CargarGraficoFormasDePago()
        {
            // --- 1. OBTENER DATOS DE SQL (Sigue igual) ---
            List<double> values = new List<double>();
            List<string> labels = new List<string>();

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            string query = @"
        SELECT
            fdp.Descripcion AS FormaDePago,
            COUNT(f.id_factura) AS Total
        FROM
            [dbo].[factura] AS f
        JOIN
            [dbo].[FormasDePago] AS fdp ON f.formadepago = fdp.FormaDePagoID
        JOIN
            [dbo].[tipo_factura] AS tf ON f.tipo_documento = tf.id
        WHERE
            tf.descripcion IN ('Factura A', 'Factura B', 'Factura C')
        GROUP BY
            fdp.Descripcion
        ORDER BY
            Total DESC;
    ";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        labels.Add(reader.GetString(0));       // Col 0: FormaDePago
                        values.Add(Convert.ToDouble(reader.GetValue(1))); // Col 1: Total
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la base de datos: " + ex.Message);
                return;
            }

            if (values.Count == 0)
            {
                MessageBox.Show("No se encontraron facturas con formas de pago para generar el gráfico.");
                return;
            }

            // --- 2. Configurar el gráfico de Torta (Modo Manual v5) ---
            FormsPlot1.Plot.Clear(); // Limpiamos el gráfico

            // --- ¡NUEVO! Calcular el total para los porcentajes ---
            double totalSum = values.Sum();

            // 3. Crear la lista de "Porciones" (Slices)
            List<ScottPlot.PieSlice> slices = new List<ScottPlot.PieSlice>();
            var palette = new ScottPlot.Palettes.Category10();

            for (int i = 0; i < values.Count; i++)
            {
                double currentValue = values[i];
                string currentLabel = labels[i];

                // --- ¡NUEVO! Calcular porcentaje y crear etiqueta para leyenda ---
                double percentage = (currentValue / totalSum) * 100.0;

                // Esta etiqueta se mostrará en la leyenda
                string legendLabel = $"{currentLabel}: {percentage:F1}% ({currentValue})";

                var slice = new ScottPlot.PieSlice
                {
                    Value = currentValue,
                    Label = legendLabel, // <-- Usamos la nueva etiqueta formateada
                    FillColor = palette.GetColor(i)
                };
                slices.Add(slice);
            }

            // 4. Añadir la lista de porciones al gráfico
            var pie = FormsPlot1.Plot.Add.Pie(slices);

            // 5. Mostrar la leyenda (Ahora mostrará la etiqueta con porcentajes)
            FormsPlot1.Plot.Legend.IsVisible = true;
            FormsPlot1.Plot.Legend.Location = ScottPlot.Alignment.MiddleRight;

            // 6. Título
            FormsPlot1.Plot.Title("Formas de Pago ");

            // 7. Ocultar los ejes
            FormsPlot1.Plot.Axes.Left.IsVisible = false;
            FormsPlot1.Plot.Axes.Bottom.IsVisible = false;

            // ¡Refrescar el gráfico!
            FormsPlot1.Refresh();
        }
    }
}