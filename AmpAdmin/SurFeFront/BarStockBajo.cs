using Microsoft.VisualBasic;
using OpenTK.Audio.OpenAL;
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

namespace SurFeFront
{
    public partial class BarStockBajo : Form
    {
        readonly FormsPlot FormsPlot1 = new FormsPlot() { Dock = DockStyle.Fill };
        public BarStockBajo()
        {
            InitializeComponent();
            panel1.Controls.Add(FormsPlot1);



            // Plot data using the control

            double[] data = ScottPlot.Generate.Sin();

            FormsPlot1.Plot.Add.Signal(data);

            FormsPlot1.Refresh();

            string input = Interaction.InputBox("Mostrar productos con stock menor a:",
                                                "Definir Stock Bajo",
                                                "10"); // "10" es el valor por defecto

            // 2. Validar que sea un número
            int stockBajo;
            if (int.TryParse(input, out stockBajo))
            {
                // 3. Si es un número, llamar al nuevo método del gráfico
                CargarGraficoStockBajo(stockBajo);
            }
            else if (!string.IsNullOrEmpty(input)) // Si el usuario escribió algo (que no sea un número)
            {
                MessageBox.Show("Por favor, introduce solo un número.");
            }
            // Si el usuario presiona "Cancelar" (input es vacío), no hacemos nada.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
    string input = Interaction.InputBox("Mostrar productos con stock menor a:",
                                        "Definir Stock Bajo",
                                        "10"); // "10" es el valor por defecto

            // 2. Validar que sea un número
            int stockBajo;
            if (int.TryParse(input, out stockBajo))
            {
                // 3. Si es un número, llamar al nuevo método del gráfico
                CargarGraficoStockBajo(stockBajo);
            }
            else if (!string.IsNullOrEmpty(input)) // Si el usuario escribió algo (que no sea un número)
            {
                MessageBox.Show("Por favor, introduce solo un número.");
            }
            // Si el usuario presiona "Cancelar" (input es vacío), no hacemos nada.
        }


        // --- Este es el NUEVO método para el gráfico de stock bajo ---
        // (Es una copia de tu código anterior, pero modificado para el stock)
        private void CargarGraficoStockBajo(int stockBajo)
        {
            // --- 1 y 2. OBTENER DATOS DE SQL (MODIFICADO) ---
            List<double> values = new List<double>();
            List<string> labels = new List<string>();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString;

            // !! NOTA !! Asumo que tu columna se llama [stock]. 
            // ¡Cámbiala si se llama [stock_actual] o similar!
            string query = @"
        SELECT 
            [detalle], 
            [stock] 
        FROM 
            [dbo].[producto] 
        WHERE 
            [stock] < @StockBajo AND [stock] > 0
        ORDER BY
            [stock] ASC"; // Ordenamos para ver los más bajos primero

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    // ¡IMPORTANTE! Usamos un parámetro para evitar Inyección SQL
                    command.Parameters.AddWithValue("@StockBajo", stockBajo);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        labels.Add(reader.GetString(0));       // Col 0: detalle
                        values.Add(Convert.ToDouble(reader.GetValue(1))); // Col 1: stock
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la base de datos: " + ex.Message);
                return;
            }

            // --- 3. Configurar el gráfico (Horizontal) ---
            FormsPlot1.Plot.Clear(); // Limpiamos el gráfico anterior (ej. el de Top 10)

            double[] dataValues = values.ToArray();
            string[] dataLabels = labels.ToArray();

            if (dataValues.Length == 0)
            {
                MessageBox.Show("No se encontraron productos con stock menor a " + stockBajo);
                return;
            }

            var barPlot = FormsPlot1.Plot.Add.Bars(dataValues);
            barPlot.Horizontal = true;
            barPlot.Color = Colors.DarkRed; // Un color rojo para "alerta"

            // 3. Asignar etiquetas de eje (al eje Izquierdo)
            Tick[] ticks = new Tick[dataLabels.Length];
            for (int i = 0; i < dataLabels.Length; i++)
            {
                ticks[i] = new Tick(i, dataLabels[i]);
            }
            FormsPlot1.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            // 4. Títulos y Etiquetas (MODIFICADO)
            FormsPlot1.Plot.Title("Productos con Stock Bajo (Menor a " + stockBajo + ")");
            FormsPlot1.Plot.XLabel("Stock Actual");
            FormsPlot1.Plot.YLabel("Producto");

            // 5. Límites de Ejes
            double maxX = dataValues.Length > 0 ? dataValues.Max() : stockBajo;
            FormsPlot1.Plot.Axes.SetLimitsX(0, maxX * 1.1);
            FormsPlot1.Plot.Axes.SetLimitsY(-0.5, dataValues.Length - 0.5);

            // --- 6. AÑADIR ETIQUETAS DE TEXTO ---
            // (Mantenemos tu petición de poner el NOMBRE dentro)
            for (int i = 0; i < dataValues.Length; i++)
            {
                string label = dataLabels[i];
                double yPos = i;
                double xPos = 0.5; // Empezamos cerca del borde izquierdo

                var text = FormsPlot1.Plot.Add.Text(label, xPos, yPos);

                text.Color = Colors.White;
                text.Bold = true;
                text.Size = 9; // Un poco más pequeño por si hay muchos productos
                text.Alignment = Alignment.MiddleLeft; // Si da error, usa 'UpperCenter'
            }

            // ¡Refrescar el gráfico!
            FormsPlot1.Refresh();
        }
    }
}
