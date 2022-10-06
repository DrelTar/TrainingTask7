using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        DataTable dataTable;
        string column;
        string name;
        public Form2(DataTable dataTable, string column, string name)
        {
            InitializeComponent();
            this.dataTable = dataTable;
            this.column = column;
            this.name = name;
        }

        /// <summary>
        /// Painting histogram form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                // Taking names.
                List<string> names = new List<string>();
                for (int i = 0; i < dataTable.Rows.Count; ++i)
                {
                    names.Add(dataTable.Rows[i][name].ToString());
                }
                // Taking values.
                int[] values = dataTable.AsEnumerable().Select(r => r.Field<Int32>(column)).ToArray();
                chart1.Series.Clear();
                Series series = new Series();
                series.ChartType = SeriesChartType.Column;
                chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
                series.Name = column;
                chart1.Series.Add(series);
                for (int i = 0; i < values.Length; i++)
                {
                    chart1.Series[column].Points.AddXY(names[i], values[i]);
                }
                // Calculating needed numbers.
                Calculate(values);
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Oh, you clicked something wrong and everything broke");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Oh, you clicked something wrong and everything broke");
            }
        }

        /// <summary>
        /// Calculating needed numbers for values.
        /// </summary>
        /// <param name="values"> Current column values. </param>
        private void Calculate(int[] values)
        {
            double middle = 0;
            double square = 0;
            for (int i = 0; i < values.Length; i++)
            {
                middle += values[i];
                square += values[i] * values[i];
            }
            middle /= values.Length;
            square /= values.Length;
            square = Math.Sqrt(square);
            Array.Sort(values);
            double median;
            if (values.Length % 2 == 0)
            {
                median = (values[values.Length / 2] + values[values.Length / 2 - 1]) / 2;
            }
            else
            {
                median = values[values.Length / 2];
            }
            double dispersion = 0;
            Array.ForEach(values, x => dispersion += (x - middle) * (x - middle));
            dispersion /= values.Length - 1;
            this.middle.Text = "Среднее " + middle.ToString();
            this.median.Text = "Медиана " + median.ToString();
            this.square.Text = "Квадратичное " + square.ToString();
            this.dispersion.Text = "Дисперсия " + dispersion.ToString();
        }
    }
}
