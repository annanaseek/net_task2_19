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

namespace net_task2_19
{
    public partial class Form1 : Form
    {
        string fileText;
        string filename;
        Logic logic;
        public Form1()
        {
            InitializeComponent();
            logic = new Logic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filename = openFileDialog1.FileName;
            // читаем файл в строку
            fileText = System.IO.File.ReadAllText(filename);
            textBox2.Text = fileText;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string chiper = textBox1.Text;
            char[] chiperArray = chiper.ToCharArray();

            try
            {
                int[] array = chiperArray.Select(x => (int)char.GetNumericValue(x)).ToArray();

                string final = logic.GetNewString(array, fileText.ToCharArray());

                textBox3.Text = final;

                using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(final);
                }
                MessageBox.Show("Проверяй файл");
            }
            catch
            {
                MessageBox.Show("Читай задание");
            }

            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
