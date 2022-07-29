using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialEstimation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string[] row = { txtCategory.Text,txtItem.Text,txtMaterial.Text,txtQty.Text,txtUnitPrice.Text,txtDescription.Text,(Convert.ToDecimal(txtQty.Text) * Convert.ToDecimal(txtUnitPrice.Text)).ToString() };
            dataGridView1.Rows.Add(row);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal totalAmount = 0;
            foreach(DataGridViewRow dgv in dataGridView1.Rows)
            {
                totalAmount = totalAmount + (Convert.ToDecimal(dgv.Cells[3].Value.ToString()) * Convert.ToDecimal(dgv.Cells[4].Value.ToString()));
            }
            lblEstimate.Text = totalAmount.ToString("#.##");
            string[] row = { "", "", "", "", "", "TOTAL ESTIMATE:",lblEstimate.Text  };
            dataGridView1.Rows.Add(row);
            SaveDataGridViewToCSV("EstimateCost.csv");
        }
        void SaveDataGridViewToCSV(string filename)
        {
            // Choose whether to write header. Use EnableWithoutHeaderText instead to omit header.
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            // Select all the cells
            dataGridView1.SelectAll();
            // Copy selected cells to DataObject
            DataObject dataObject = dataGridView1.GetClipboardContent();
            // Get the text of the DataObject, and serialize it to a file
            File.WriteAllText(filename, dataObject.GetText(TextDataFormat.CommaSeparatedValue));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtUnitPrice.Clear();
            txtQty.Clear();
            txtMaterial.Clear();
            txtItem.Clear();
            txtDescription.Clear();
            txtCategory.Clear();
        }
    }
}
