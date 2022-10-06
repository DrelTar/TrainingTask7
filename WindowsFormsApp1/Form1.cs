using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
           InitializeComponent();
        }

        /// <summary>
        /// Read csv file, calculate column types and show main data table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Opening file.
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv file|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Reading file.
                    DataTable tmpDataTable = new DataTable();
                    string filePath = openFileDialog.FileName;
                    StreamReader streamReader = new StreamReader(filePath);
                    Array.ForEach(TakeData(streamReader), x => tmpDataTable.Columns.Add(x));
                    // Adding rows.
                    while (!streamReader.EndOfStream)
                    {
                        DataRow row = tmpDataTable.NewRow();
                        string[] data = TakeData(streamReader);
                        for (int i = 0; i < data.Length; ++i)
                        {
                            row[i] = data[i];
                        }
                        tmpDataTable.Rows.Add(row);
                    }
                    // Cloning data tableto change column types.
                    DataTable dataTable = tmpDataTable.Clone();
                    foreach (DataColumn column in tmpDataTable.Columns)
                    {
                        if (tmpDataTable.AsEnumerable().All(x => int.TryParse(x.Field<string>(column.ColumnName), out int tmp)))
                        {
                            dataTable.Columns[column.ColumnName].DataType = typeof(Int32);
                        }
                    }
                    foreach (DataRow row in tmpDataTable.Rows)
                    {
                        dataTable.ImportRow(row);
                    }
                    // Showing data table.
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        /// <summary>
        /// Reading new row.
        /// </summary>
        /// <param name="streamReader"> Current data stream. </param>
        /// <returns> Row. </returns>
        private string[] TakeData(StreamReader streamReader)
        {
            string tmpString = streamReader.ReadLine();
            // Removing wrong ".
            if (tmpString[0] == '"')
            {
                tmpString = tmpString.Remove(0, 1);
            }
            if (tmpString[tmpString.Length - 1] == '"')
            {
                tmpString = tmpString.Remove(tmpString.Length - 1);
            }
            // It's for "some, some" type of value.
            string[] tmpData = tmpString.Replace("\",\"", "\"#").Replace(",\"", "\"#").Replace("\",", "\"").Split('"');
            List<string> data = new List<string>();
            for (int i = 0; i < tmpData.Length; ++i)
            {
                if (tmpData[i][0] != '#')
                {
                    for (int j = 0; j < tmpData[i].Split(',').Length; ++j)
                    {
                        // E number handling.
                        if (tmpData[i].Split(',')[j].Contains("e+") && double.TryParse(tmpData[i].Split(',')[j]
                            .Replace("e+", "e").Split('e')[0].Replace(".", ","), out double a) &&
                            int.TryParse(tmpData[i].Split(',')[j].Replace("e+", "e").Split('e')[1], out int b))
                        {
                            data.Add($"{a * Math.Pow(10, b)}");
                        }
                        else if (tmpData[i].Split(',')[j] != "")
                        {
                            data.Add(tmpData[i].Split(',')[j]);
                        }
                        else
                        {
                            data.Add($"{data.Count + 1}");
                        }
                    }
                }
                // "Some, some" value handling.
                else
                {
                    data.Add(tmpData[i].Replace("#", ""));
                }
            }
            // Returning row.
            return data.ToArray();
        }

        /// <summary>
        /// Creating new histogram form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = ((DataTable)dataGridView1.DataSource);
            if (values.Text != "" && names.Text != "")
            {
                Form2 newForm = new Form2(dataTable, values.Text, names.Text);
                newForm.Show();
            }
        }
    }
}
