using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace CryptographicApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Функционал

        public void Clear(bool a)
        {
            if (a == true)
            {
                tb_SourceData.Text = "";
            }
            else
            {
                tb_EncryptedData.Text = "";
            }
        }

        public void Font_Size (bool a, bool b)
        {
            double fs1 = tb_SourceData.FontSize;
            double fs2 = tb_EncryptedData.FontSize;

            if (a == true) //выбор кнопки
            {
                if (b == true) //выбор опериции
                {
                    if (tb_SourceData.FontSize < 24)
                        tb_SourceData.FontSize = ++fs1;
                }
                else
                {
                    if (tb_SourceData.FontSize > 1)
                        tb_SourceData.FontSize = --fs1;
                }
            }
            else
            {
                if (b == true) //выбор опериции
                {
                    if (tb_EncryptedData.FontSize < 24)
                        tb_EncryptedData.FontSize = ++fs2;
                }
                else
                {
                    if (tb_EncryptedData.FontSize > 1)
                        tb_EncryptedData.FontSize = --fs2;
                }
            }
        }

        public void File_Selection()
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                tb_FileName.Text = openFileDlg.FileName;
                tb_SourceData.Text = File.ReadAllText(openFileDlg.FileName, Encoding.Default);
            }
        }

        #endregion

        #region Элементы формы

        private void Btn_Clear_1_Click(object sender, RoutedEventArgs e)
        {
            Clear(true);
        }

        private void Btn_Clear_2_Click(object sender, RoutedEventArgs e)
        {
            Clear(false);
        }

        private void Btn_Increase_1_Click(object sender, RoutedEventArgs e)
        {
            Font_Size(true, true);
        }

        private void Btn_Increase_2_Click(object sender, RoutedEventArgs e)
        {
            Font_Size(false, true);
        }

        private void Btn_Reduce_1_Click(object sender, RoutedEventArgs e)
        {
            Font_Size(true, false);
        }

        private void Btn_Reduce_2_Click(object sender, RoutedEventArgs e)
        {
            Font_Size(false, false);
        }

        private void Btn_FileSelection_Click(object sender, RoutedEventArgs e)
        {
            File_Selection();
        }

        private void Menu_btn_FileSelection_Click(object sender, RoutedEventArgs e)
        {
            File_Selection();
        }

        private void Menu_btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        
    }
}