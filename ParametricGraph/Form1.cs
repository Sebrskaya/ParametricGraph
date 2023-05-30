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
            PlotComplexGraph();
        }

        private void PlotComplexGraph()
        {
            double tStep = 0.01;
            List<double> xValues1 = new List<double>();
            List<double> yValues1 = new List<double>();
            List<double> xValues2 = new List<double>();
            List<double> yValues2 = new List<double>();
            List<double> xValues3 = new List<double>();
            List<double> yValues3 = new List<double>();
            List<double> xValues4 = new List<double>();
            List<double> yValues4 = new List<double>();

            for (double t = -2 * Math.PI; t <= 2* Math.PI ; t += tStep)
            {
                Complex z1 = new Complex(2 * Math.Cos(t), 1 * Math.Sin(t));

                xValues1.Add(z1.Real);
                yValues1.Add(z1.Imaginary);
            }

            for (double t = -1 ; t <= 1; t += tStep)
            {
                Complex z2 = new Complex(1, 1 * t);
                Complex z3 = z2 * z2;
                

                xValues2.Add(z3.Real);
                yValues2.Add(z3.Imaginary);

                xValues3.Add(-z3.Real);
                yValues3.Add(-z3.Imaginary);
                
                xValues4.Add(z2.Real);
                yValues4.Add(z2.Imaginary);
            }

            PlotGraph(xValues1.ToArray(), yValues1.ToArray(), "Series1",chart1);
            PlotGraph(xValues2.ToArray(), yValues2.ToArray(), "Series2", chart1);
            PlotGraph(xValues3.ToArray(), yValues3.ToArray(), "Series3", chart1);
            PlotGraph(xValues4.ToArray(), yValues4.ToArray(), "Series4", chart2);
        }

        private void PlotGraph(double[] x, double[] y, string seriesName, Chart chart)
        {
            
            chart.Series[seriesName].ChartType = SeriesChartType.Point;

            for (int i = 0; i < x.Length; i++)
            {
                chart.Series[seriesName].Points.AddXY(x[i], y[i]);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            PlotComplexGraph();
        }
    }

    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new Complex(real, imaginary);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            double real = a.Real + b.Real;
            double imaginary = a.Imaginary + b.Imaginary;
            return new Complex(real, imaginary);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            double real = a.Real - b.Real;
            double imaginary = a.Imaginary - b.Imaginary;
            return new Complex(real, imaginary);
        }

        public static Complex Exp(Complex z)
        {
            double expReal = Math.Exp(z.Real);
            double real = expReal * Math.Cos(z.Imaginary);
            double imaginary = expReal * Math.Sin(z.Imaginary);
            return new Complex(real, imaginary);
        }
    }
}
