using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        bool drawing; 
        GraphicsPath currentPath; 
        Point oldLocation;
        Pen currentPen;
        Color historyColor;

        int historyCounter; //Счетчик истории 


        List<Image> History; //Список для истории

        public Form1() {
            InitializeComponent(); 
            drawing = false;  //Переменная, ответственная за рисование
            currentPen = new Pen(Color.Black); //Инициализация пера с черным цветом
            currentPen.Width = trackBarPen.Value;
            History = new List<Image>();

            Bitmap pic = new Bitmap(536, 358);
            using (var g = Graphics.FromImage(pic))
                g.Clear(Color.White);
            picDrawingSurface.Image = pic;
            History.Clear();
            historyCounter = 0;
            History.Add(new Bitmap(picDrawingSurface.Image));
        }


        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("");
            if (picDrawingSurface.Image != null) {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                switch (result) { case DialogResult.No: break;
                case DialogResult.Yes: сохранитьToolStripMenuItem_Click(sender, e); break; 
                case DialogResult.Cancel: return; } }

            Bitmap pic = new Bitmap(536, 358);
            using (var g = Graphics.FromImage(pic))
                g.Clear(Color.White);
            picDrawingSurface.Image = pic;
         History.Clear(); 
            historyCounter = 0;
                History.Add(new Bitmap(picDrawingSurface.Image)); 
        }

        private void picDrawingSurface_MouseDown(object sender, MouseEventArgs e)
        {
            if (picDrawingSurface.Image == null) 
            { 
                MessageBox.Show("Сначала создайте новый файл!"); 
                return; }
            if (e.Button == MouseButtons.Left)
            { drawing = true;
                oldLocation = e.Location;
                currentPath = new GraphicsPath(); 
            }
            else if (e.Button == MouseButtons.Right)
            {
                historyColor = currentPen.Color;
                currentPen.Color = Color.White;
                drawing = true;
                oldLocation = e.Location;
                currentPath = new GraphicsPath(); 
            } 

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog(); 
            SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png"; 
            SaveDlg.Title = "Save an Image File"; 
            SaveDlg.FilterIndex = 4; //По умолчанию будет выбрано последнее расширение *.png 
            SaveDlg.ShowDialog();
if (SaveDlg.FileName != "") //Если введено не пустое имя 
            { System.IO.FileStream fs = (System.IO.FileStream)SaveDlg.OpenFile(); 
                switch (SaveDlg.FilterIndex) 
                { case 1: this.picDrawingSurface.Image.Save(fs, ImageFormat.Jpeg);
                    break; case 2: this.picDrawingSurface.Image.Save(fs, ImageFormat.Bmp);
                        break; case 3: this.picDrawingSurface.Image.Save(fs, ImageFormat.Gif); break;
                    case 4: this.picDrawingSurface.Image.Save(fs, ImageFormat.Png); break;   } 
    fs.Close(); }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog(); 
            OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png"; 
            OP.Title = "Open an Image File"; 
            OP.FilterIndex = 1; //По умолчанию будет выбрано первое расширение *.jpg И, когда пользователь укажет нужный путь к картинке, ее нужно будет загрузить в PictureBox:
           if (OP.ShowDialog() != DialogResult.Cancel) 
               picDrawingSurface.Load(OP.FileName); 
            picDrawingSurface.AutoSize = true;
        }

        private void создатьToolStripButton_Click(object sender, EventArgs e)
        {
            if (picDrawingSurface.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение перед созданием нового рисунка?", "Предупреждение", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: сохранитьToolStripMenuItem_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }

            Bitmap pic = new Bitmap(536, 358);
            using (var g = Graphics.FromImage(pic))
                g.Clear(Color.White);
            picDrawingSurface.Image = pic;
            History.Clear();
            historyCounter = 0;
            History.Add(new Bitmap(picDrawingSurface.Image)); 
        }

        private void picDrawingSurface_MouseUp(object sender, MouseEventArgs e)
        {

            drawing = false;
            if (e.Button == MouseButtons.Right)
            {
                currentPen.Color = historyColor;
            }
       
            try { currentPath.Dispose();


            History.RemoveRange(historyCounter + 1, History.Count - historyCounter - 1);
            History.Add(new Bitmap(picDrawingSurface.Image));
            if (historyCounter + 1 < 10) historyCounter++;
            if (History.Count - 1 == 10)
                History.RemoveAt(0); 
            }
            catch { }; 
        }

        private void picDrawingSurface_MouseMove(object sender, MouseEventArgs e)
        {
            label_XY.Text = e.X.ToString() + ", " + e.Y.ToString();
           if (drawing) 
           { Graphics g = Graphics.FromImage(picDrawingSurface.Image);
               currentPath.AddLine(oldLocation, e.Location); 
               g.DrawPath(currentPen, currentPath);
               oldLocation = e.Location; g.Dispose(); 
               picDrawingSurface.Invalidate();
             
           } 
        }

        private void trackBarPen_Scroll(object sender, EventArgs e)
        {
            currentPen.Width = trackBarPen.Value;
        }

        private void отменадействияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (History.Count != 0 && historyCounter != 0) { 
                picDrawingSurface.Image = new Bitmap(History[--historyCounter]); } 
            else MessageBox.Show("История пуста"); 
        }

        private void отменадействияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (historyCounter < History.Count - 1) 
            { picDrawingSurface.Image = new Bitmap(History[++historyCounter]); } 
            else MessageBox.Show("История пуста"); 
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Solid;
            solidToolStripMenuItem.Checked = true;
            dotToolStripMenuItem.Checked = false;
            dashDotDotToolStripMenuItem.Checked = false;
        }

        private void dotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.Dot;
            solidToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = true;
            dashDotDotToolStripMenuItem.Checked = false;
        }

        private void dashDotDotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPen.DashStyle = DashStyle.DashDotDot;
            solidToolStripMenuItem.Checked = false;
            dotToolStripMenuItem.Checked = false;
            dashDotDotToolStripMenuItem.Checked = true;
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4; //По умолчанию будет выбрано последнее расширение *.png 
            SaveDlg.ShowDialog();
            if (SaveDlg.FileName != "") //Если введено не пустое имя 
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDlg.OpenFile();
                switch (SaveDlg.FilterIndex)
                {
                    case 1: this.picDrawingSurface.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2: this.picDrawingSurface.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3: this.picDrawingSurface.Image.Save(fs, ImageFormat.Gif); break;
                    case 4: this.picDrawingSurface.Image.Save(fs, ImageFormat.Png); break;
                }
                fs.Close();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            currentPen.Color = colorDialog1.Color;
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1; //По умолчанию будет выбрано первое расширение *.jpg И, когда пользователь укажет нужный путь к картинке, ее нужно будет загрузить в PictureBox:
            if (OP.ShowDialog() != DialogResult.Cancel)
                picDrawingSurface.Load(OP.FileName);
            picDrawingSurface.AutoSize = true;
        }


    }
}
