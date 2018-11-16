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
        public fMain()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //открывает файл рома
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // чтение из файла
            using (FileStream fstream = File.OpenRead(filename))
            {
                // преобразуем строку в байты
                byte[] byte_in = new byte[fstream.Length];
                // считываем данные
                fstream.Read(byte_in, 0, byte_in.Length);
                // декодируем байты в строку
                //string textFromFile = System.Text.Encoding.Default.GetString(array);
                //textBox1.Text = textFromFile;
                //textBox2.Text = byte_in.ToString();
                //textBox2.Text = Convert.ToString(byte_in);
                //int KCells = 1, IJ = 0;
                //string[] HexTabl = new string[byte_in.Length];
                string HexTabl2="";
                for (int i1 = 0; i1 < (byte_in.Length); i1++)    //общее количество ячеек
                {
                    //dataGridView1.Rows.Add();
                    //dataGridView1.Rows[i1].Cells[0].Value = (i1 + 1).ToString();   //номер столбца, потом изменить на 00000->00016 и т.д.
                    //while (KCells != 17)
                    //{
                    //if (IJ < byte_in.Length)
                    //{
                    HexTabl2 += Convert.ToString(byte_in[i1], 16);
                    //dataGridView1.Rows[i1].Cells[KCells].Value = HexTabl;  //добавление 1 и 2 символа в 1 ячейку
                    //KCells++;
                    //IJ = IJ + 1;
                    //}
                    //else
                    //{
                    // break;
                    // }
                    // }           
                    // KCells = 1;
                }
                //for (int i1 = 0; i1 < (byte_in.Length); i1++)    //общее количество ячеек
                //{
                    textBox1.Text = HexTabl2;
                //}
                    //if (byte_in.Length % 16 == 0)
                    //{
                    //    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                    //}
                }//*/


            /*//открывает файл рома
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            String fileText = File.ReadAllText(filename, Encoding.Default);
            //textBox1.Text = fileText;
            //представление текста в hex виде
            byte[] key;
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                key = new byte[fs.Length];
                fs.Read(key, 0, (int)fs.Length);
            }
            textBox2.Text = (BitConverter.ToString(key).Replace('-', ' '));
            string HextoSTR = textBox2.Text;
            //textBox1.Text = HextoSTR;
            textBox1.Text = System.Text.RegularExpressions.Regex.Replace(HextoSTR, @"\s+", "");
            string Tabl = textBox1.Text;
    
            int KRows=0, KCells=1, IJ=0;                                //счётчик для столбцов
                
            for (int i1 = 0; i1 < ((Tabl.Length/(2*16))+1); i1++)    //общее количество ячеек
            {
                dataGridView1.Rows.Add();              
                dataGridView1.Rows[i1].Cells[0].Value = (i1 + 1).ToString();   //номер столбца, потом изменить на 00000->00016 и т.д.
                while (KCells != 17)
                {
                    if (IJ < Tabl.Length)
                    {
                        string HexTabl = System.Convert.ToString(Tabl[IJ]);
                        HexTabl = HexTabl + System.Convert.ToString(Tabl[IJ + 1]);
                        dataGridView1.Rows[KRows].Cells[KCells].Value = HexTabl;  //добавление 1 и 2 символа в 1 ячейку
                        KCells++;
                        IJ = IJ + 2;
                    }
                    else
                    {
                        break;
                    }
                }
                KCells=1;
                KRows++;            
            }
            if (IJ%32==0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
            }

/*
            //№ строки добавляем в первый столбец Cells[0]
            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            //текст добавим во второй столбец Cells[1]
            dataGridView1.Rows[i].Cells[1].Value = "пример текста";

            i++;          //переходим к следующей строке
            dataGridView1.Rows.Add();
            dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();*/



            int K = textBox1.Text.Length;
            K = K / 2;  //количество байт в файле: 16-тиричное представление разделённое на 2. То есть 2 байта - 1 буква
            textBox3.Text = K.ToString()+" байт";
            //textBox3.Text = HextoSTR;            
            //string ASCIISymbol = Char.ConvertFromUtf32(Convert.ToInt32(textBox3.Text, 16));
            //textBox1.Text = ASCIISymbol;

            //string hex = ("47-61-74-65-77-61-79-53-65-72-76-65-72");
            /*string hex = textBox3.Text;
            //byte[] data = FromHex("47-61-74-65-77-61-79-53-65-72-76-65-72");
            byte[] data;
            //hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            data = raw;
            //string s = Encoding.ASCII.GetString(data);
            //textBox3.Text = s;*/
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
