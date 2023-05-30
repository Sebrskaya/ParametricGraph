using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ParametricGraph
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Click += chart1_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PlotParametricGraph();
        }

        private void PlotParametricGraph()
        {
            // Parameters for the graph
            double scaleX = 6.2;
            double scaleY = 6.2;

            // Step size for parameter t
            double tStep = 0.01;

            // Lists to store x and y values
            List<double> xValues = new List<double>();
            List<double> yValues = new List<double>();

            // Calculate x and y values for the graph
            for (double t = 0; t <= 20 * Math.PI; t += tStep)
            {
                double x = scaleX * (Math.Cos(t) - Math.Cos(3.1 * t) / 3.1);
                double y = scaleY * ((Math.Sin(t) - Math.Sin(3.1 * t)) / 3.1);

                xValues.Add(x);
                yValues.Add(y);
            }

            // Plot the parametric graph
            PlotGraph(xValues.ToArray(), yValues.ToArray());
        }

        private void PlotGraph(double[] x, double[] y)
        {
            chart1.Series["Series1"].Points.Clear();

            // Add points to the graph series
            for (int i = 0; i < x.Length; i++)
            {
                chart1.Series["Series1"].Points.AddXY(x[i], y[i]);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            PlotParametricGraph();
        }
    }
}
