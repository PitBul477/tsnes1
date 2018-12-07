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
            richTextBox1.Clear();
            richTextBox2.Clear();
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
            //richTextBox1.Text = Encoding.Default.GetString(bytes);
            //richTextBox1.Text = Convert.ToString((char)bytes[5]);System.Text.Encoding encoding
            int K = HexTabl2.Length;
            K = K / 2;  //количество байт в файле: 16-тиричное представление разделённое на 2. То есть 2 байта - 1 буква
            textBox3.Text = K.ToString() + " байт";

            //richTextBox1.Text = Convert.ToString(dataGridView2.Rows.Count - 1);
            if (dataGridView2.Rows.Count > 1)
            {
                while (HexTabl2.Count() > 1)
                {
                    string Test;
                    Test = Convert.ToString(HexTabl2[0]) + Convert.ToString(HexTabl2[1]);
                    for (int i = 1; i < dataGridView2.Rows.Count; i++)
                    {

                        //*richTextBox1.Text = Convert.ToString(i);
                        if (Test == dataGridView2[0, i].Value.ToString())
                        {
                            richTextBox1.AppendText(dataGridView2[1, i].Value.ToString());
                            if (HexTabl2.Count() > 2)
                                HexTabl2 = HexTabl2.Substring(3);
                            else HexTabl2 = HexTabl2.Substring(2);
                            break;
                        }//*/
                         //string F = dataGridView2[0, i].Value.ToString();
                         //richTextBox1.AppendText(F+" "+ Test + "\n");
                        if (i == (dataGridView2.Rows.Count - 1))
                        {
                            richTextBox1.AppendText(";");
                            HexTabl2 = HexTabl2.Substring(2);
                        }
                    }//*/

                }
            }
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

        private void открытьоригиналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //удаление прошлого результата
            while (dataGridView2.Columns.Count != 0)
                dataGridView2.Columns.RemoveAt(0);
            
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "HEX"; //текст в шапке
            column1.Width = 50; //ширина колонки
            //column1.ReadOnly = true; //значение в этой колонке нельзя править
            //column1.Name = "name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте

            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Символ"; //текст в шапке
            column2.Width = 50; //ширина колонки
            column2.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column2.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            //запись в dataGridView2, причём первый столбец должен быть неизменяем, и при выводе сортироваться по атфавиту. Второй столбец должен быть изменяемый
            dataGridView2.Columns.Add(column1);
            dataGridView2.Columns.Add(column2);
            dataGridView2.Columns[0].Resizable = DataGridViewTriState.False;
            dataGridView2.Columns[1].Resizable = DataGridViewTriState.False;
            dataGridView2.AllowUserToAddRows = false;

            string FileText;
            List<List<object>> list = new List<List<object>>(); //инициализация
            //list.Add(new List<object>());//добавление новой строки
            //list[0].Add("asd")//добавление столбца в новую строку
            //list[0][0];//обращение к первому столбцу первой строки
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            FileText = File.ReadAllText(filename, Encoding.Default);
            string[] Test = File.ReadAllLines(filename, Encoding.Default);
            foreach (string N in Test)
            {
                list.Add(new List<object>());
                int K = list.Count() - 1;
                list[K].Add(Convert.ToString(N[0]) + Convert.ToString(N[1]));
                list[K].Add(N[3]);
            }

            //проверка на повторяющееся значение (если есть повторения, то вывести для выбора)

            //проверка на незаполненые значения, и замена их на стандартные в случае чего

            for (int N = 0; N < list.Count(); N++)
            {
                //richTextBox1.AppendText(Convert.ToString(list[N][0]) + " " + Convert.ToString(list[N][1]) + "\n");

                dataGridView2.Rows.Add(Convert.ToString(list[N][0]), Convert.ToString(list[N][1]));
            }


        }
    }
}
