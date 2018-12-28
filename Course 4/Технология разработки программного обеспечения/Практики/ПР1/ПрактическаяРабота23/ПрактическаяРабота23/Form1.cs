using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПрактическаяРабота23
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            pictureBox1.ContextMenuStrip = contextMenuStrip5;

            открытьИзФайлаToolStripMenuItem1.Click += открытьИзФайлаToolStripMenuItem_Click;
            сохранитьКакToolStripMenuItem1.Click += сохранитьКакToolStripMenuItem_Click;

            сохранитьКакToolStripMenuItem1.Enabled = false;
            сохранитьКакToolStripMenuItem.Enabled = false;
        }

         // Загружаем изображени
        public void LoadImg(string path)
        {
            Image image = Image.FromFile(path);
            int width = image.Width;
            int height = image.Height;
            pictureBox1.Image = image;
            pictureBox1.Width = width;
            pictureBox1.Height = height;

            сохранитьКакToolStripMenuItem1.Enabled = true;
            сохранитьКакToolStripMenuItem.Enabled = true;
        }

        private void открытьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
               // Описываем объект класса OpenFileDialog
                OpenFileDialog dialog = new OpenFileDialog();
            
                // Задаем расширения файлов
                dialog.Filter = "Image files (*.BMP, *.JPG,*.GIF, *.PNG)|*.bmp;*.jpg;*.gif;*.png";
            
                // Вызываем диалог и проверяем выбран ли файл
                if (dialog.ShowDialog() == DialogResult.OK)
                    LoadImg(dialog.FileName);
        }

        //
        private void логанToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\Lumia930.jpg");
        }

        private void дастерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\Lumia730.jpg");
        }

        private void флюенсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\XLDualSim.jpg");
        }

        //

        private void логан1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\GalaxyA5.jpg");
        }

        private void дастер1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\GalaxyS7.jpg");
        }

        private void флюенс1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\GalaxyS6Edge.jpg");
        }

        //

        private void логан2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\G4.jpg");
        }

        private void дастер2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\Nexus5X.jpg");
        }

        private void флюенс2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImg(@"C:\Users\alex0\OneDrive\Рабочий стол\Практики\ПР1\Новая папка (2)\K10LTE.jpg");
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Действия при нажатии кнопки сохранения файла
            // Описываем и порождаем объект savedialog
            SaveFileDialog savedialog = new SaveFileDialog();
            // Задаем свойства для savedialog
            savedialog.Title = "Сохранить картинку как..."; savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
            "Bitmap File(*.bmp)|*.bmp|" + "GIF File(*.gif)|*.gif|" + "JPEG File(*.jpg)|*.jpg|" + "PNG File(*.png)|*.png";
            
            // Показываем диалог и проверяем, задано ли имя файла
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = savedialog.FileName;
                // Убираем из имени расширение файла
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                
                // Сохраняем файл в нужном формате
                switch (strFilExtn)
                {
                    case "bmp":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                    
                    case "gif":
                         pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                    case "tif":
                        pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                    break;
                    case "png":
                         pictureBox1.Image.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                    default:
                    break;
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void открытьИзФайлаToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void рисункиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip5_Opening(object sender, CancelEventArgs e)
        {

        }


        private void фокусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LoadImg(@"C:\Users\kbstudentint\Pictures\Burban\_focus.jpg");
        }



    }
}
