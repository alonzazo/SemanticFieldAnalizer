using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SemanticFieldAnalizer
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnBrowseText_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;
            
            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK ? true : false)
            {
                // Open the selected file to read.
                TxtTextPath.Text = openFileDialog1.FileName;
                checkConditions();
            }
        }

        private void btnBrowseDiccionary_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV Files (.csv)|*.csv|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() == DialogResult.OK ? true : false)
            {
                // Open the selected file to read.
                TxtDictionaryPath.Text = openFileDialog1.FileName;
                checkConditions();
            }
        }

        private bool verifyCSV() {
            try {
                string[] csv = System.IO.File.ReadAllLines(TxtDictionaryPath.Text);
                int lineNum = 1;
                foreach (string row in csv) {
                    string[] words = row.Split(',');
                    if (words.Length < 2) {
                        TxtConsole.Text += "\r\n" + "EXCEPCIÓN: \tLinea " + lineNum + " no respeta estructura CSV.";
                        TxtConsole.Text += "\r\n" + "SUGERENCIA: \tRevisar línea especificada.";
                        TxtConsole.Text += "\r\n" + "DETALLE: \r\n" + row;
                        MessageBox.Show("Estructura de CSV inválida. Revise el archivo.");
                        TxtDictionaryPath.Text = "";
                        return false;
                    }
                    lineNum++;
                }
                TxtConsole.Text += "\r\n" + "VERIFICACIÓN DE CSV EXITOSA";
                return true;
            }
            catch (Exception ex) {
                TxtConsole.Text += "\r\n" + "EXCEPCIÓN:\tLectura del diccionario";
                TxtConsole.Text += "\r\n" + "SUGERENCIA:\tVerifique la ruta";
                TxtConsole.Text += "\r\n" + "DETALLE:\n" + ex.ToString();
                return false;
            }
            
        }

        private bool verifyText() {
            try
            {
                string[] csv = System.IO.File.ReadAllLines(TxtTextPath.Text);
               
                TxtConsole.Text += "\r\n" + "VERIFICACIÓN DE RUTA DE TEXTO EXITOSA";
                return true;
            }
            catch (Exception ex)
            {
                TxtConsole.Text += "\r\n" + "EXCEPCIÓN:\tLectura del texto objetivo";
                TxtConsole.Text += "\r\n" + "SUGERENCIA:\tVerifique la ruta";
                TxtConsole.Text += "\r\n" + "DETALLE:\n" + ex.ToString();
                return false;
            }
        }

        private void checkConditions() {
            if (verifyCSV() && verifyText())
            {
                BtnAnalize.Enabled = true;
            }
            else {
                BtnAnalize.Enabled = false;
            }
        }

        private void verifyTextBoxes(object sender, EventArgs e)
        {
            checkConditions();
        }

        private void BtnAnalize_Click(object sender, EventArgs e)
        {
            //MOSTRAR LOS RESULTADOS
        }
    }
}
