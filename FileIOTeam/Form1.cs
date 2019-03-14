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

namespace FileIOTeam
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnchoosefile_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            // only Text file
            openFileDialog1.Filter = "txt files (*.txt)|";

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog1.FileName;

                }
                else
                {
                    MessageBox.Show("file is empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    string text = File.ReadAllText(textBox1.Text);

                    var enctext = EncDecHandler.EncryptString(text);

                    TextWriter txt = new StreamWriter(@"C:\\demoEnc.txt");
                    txt.Write(enctext);
                    txt.Close();

                    MessageBox.Show("file is Encrypted successfully Location : C:\\demoEnc.txt");
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("file is empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    string text = File.ReadAllText(textBox1.Text);

                    var enctext = EncDecHandler.DecryptString(text);

                    TextWriter txt = new StreamWriter(@"C:\\demoDec.txt");
                    txt.Write(enctext);
                    txt.Close();

                    MessageBox.Show("file is Decrypted successfully Location : C:\\demoDec.txt");
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("file is empty");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}