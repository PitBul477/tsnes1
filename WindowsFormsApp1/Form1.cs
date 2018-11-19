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

namespace WindowsFormsApp1
{

    public partial class fMain : Form
    {
        private const string V = "\n";

        public fMain()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string HexTabl2 = "";
            //открывает файл рома
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // чтение из файла
            var bytes = File.ReadAllBytes(filename);
            HexTabl2 = BitConverter.ToString(bytes);
            richTextBox2.Text = HexTabl2;
            richTextBox3.Text = Encoding.Default.GetString(bytes);
            int K = HexTabl2.Length;
            K = K / 2;  //количество байт в файле: 16-тиричное представление разделённое на 2. То есть 2 байта - 1 буква
            textBox3.Text = K.ToString()+" байт";
            HexTabl2 = "";
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //сохраняет файл рома
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //закрывает файл рома
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //открывает файл перевода (.txt)
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //сохраняет файл перевода (.txt)
        }

        private void закрытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //закрывает файл перевода (.txt)
        }
    }
}
