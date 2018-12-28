using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ThreadExample1
{
    public partial class Form1 : Form
    {
      
        string filename;

        public Form1()
        {
            InitializeComponent();
        }

        private void Forml_Load(object sender, EventArgs e)
        {
            textBoxl.Multiline = true;
            textBoxl.Clear();
            buttonl.TabIndex = 0;
            this.Text = "Здесь кодировка Unicode";
            filename = "input.txt";
        }

        private void buttonl_Click(object sender, EventArgs e)
        {
            try
            {
                var reader = new StreamReader(filename);
                textBoxl.Text = reader.ReadToEnd();
                reader.Close();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message + "\n" +"Такого файла не существует ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception otherex)
            {  
                MessageBox.Show(otherex.Message, "Ошибка",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var writer = new StreamWriter(filename, true);
                writer.Write(textBoxl.Text);
                writer.Close();
                File.WriteAllText("input.txt", textBoxl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}