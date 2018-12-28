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

namespace Текстовый_редактор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.Clear();
            openFileDialog1.FileName = @"D:\test.txt";
            openFileDialog1.Filter = "Текстовые файлы (*.txt) | *.txt | All files (*.*) | *.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt) | *.txt* | All files (*.*)| *.*";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == String.Empty) return;
            try
            {
                var reader = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding(1251));
                textBox1.Text = reader.ReadToEnd();
                reader.Close();
            }
            catch (FileNotFoundException situation)
            {
                //MessageBox.Show(situation + "Такого файла нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception situation)
            {
                MessageBox.Show(situation.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save();
            }
        }

        private void Save()
        {
            try
            {
                var Save = new System.IO.StreamWriter(saveFileDialog1.FileName, false,
                System.Text.Encoding.GetEncoding(1251));
                Save.Write(textBox1.Text);
                Save.Close();
                textBox1.Modified = false;
            }
            catch (Exception situation)
            {
                MessageBox.Show(situation.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Modified == false) return;
            var MBox = MessageBox.Show("Текст был изменен." + " Сохранить изменения?", "Простой редактор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (MBox == DialogResult.No) return;
            if (MBox == DialogResult.Cancel) e.Cancel = true;
            if (MBox == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Save();
                    return;
                }
                else
                    e.Cancel = true;
            }
        }
    }
}
