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

        #region Переменные

        Functional func_obj;
        Transposition trans_obj;
        Monoalphabetic mono_obj;
        Polyalphabetic poly_obj;
        XOR xor_obj;
        Vernam vernam_obj;
        RSA rsa_obj;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            rb_Encryption.IsChecked = true;
            func_obj = new Functional();
            trans_obj = new Transposition();
            mono_obj = new Monoalphabetic();
            poly_obj = new Polyalphabetic();
            xor_obj = new XOR();
            vernam_obj = new Vernam();
            rsa_obj = new RSA();
        }

        #region Функционал

        #region Алгоритмы

        public void Transposition_Cipher()
        {
            trans_obj.SetKey(tb_Key.Text);

            if (rb_Encryption.IsChecked == true)
            {
                tb_EncryptedData.Text = trans_obj.Encrypt(tb_SourceData.Text);
            }
            else
            {
                tb_EncryptedData.Text = trans_obj.Decrypt(tb_SourceData.Text);
            }
        }

        public void Monoalphabetic_Cipher()
        {
            if (rb_Encryption.IsChecked == true)
            {
                tb_EncryptedData.Text = mono_obj.Encrypt(tb_SourceData.Text, Convert.ToInt32(tb_Key.Text));
            }
            else
            {
                tb_EncryptedData.Text = mono_obj.Decrypt(tb_SourceData.Text, Convert.ToInt32(tb_Key.Text));
            }
        }

        public void Polyalphabetic_Cipher()
        {
            if (rb_Encryption.IsChecked == true)
            {
                tb_EncryptedData.Text = poly_obj.Encrypt(tb_SourceData.Text, tb_Key.Text);
            }
            else
            {
                tb_EncryptedData.Text = poly_obj.Decrypt(tb_SourceData.Text, tb_Key.Text);
            }
        }

        public void Vernam_Cipher()
        {
            tb_EncryptedData.Text = vernam_obj.Encrypt_and_Decrypt(tb_SourceData.Text, tb_Key.Text);
        }

        public void XOR_Cipher()
        {
            tb_EncryptedData.Text = xor_obj.Encrypt_and_Decrypt(tb_SourceData.Text, tb_Key.Text);
        }

        public void RSA_Cipher()
        {


            if (rb_Encryption.IsChecked == true)
            {
                tb_EncryptedData.Text = rsa_obj.Encrypt(tb_SourceData.Text, tb_Key.Text, tb_Key_2.Text);
            }
            else
            {
                String[] s = tb_SourceData.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> sourcetext = new List<string>(s);

                tb_EncryptedData.Text = rsa_obj.Decrypt(sourcetext, tb_Key.Text, tb_Key_2.Text);
            }
        }

        #endregion

        #region Прочие функции

        public void File_Selection(TextBox localFileName, TextBox localFileText)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            openFileDlg.DefaultExt = ".txt";
            openFileDlg.Filter = "Текстовый документ (.txt) | * .txt";
            openFileDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                localFileName.Text = openFileDlg.FileName;
                localFileText.Text = File.ReadAllText(openFileDlg.FileName, Encoding.Default);
            }
        }

        public void Changed_File_Name_TB(TextBox ChangedTB, Button BtnUsed, MenuItem MIUsed)
        {
            if (ChangedTB.Text == "")
            {
                BtnUsed.IsEnabled = false;
                MIUsed.IsEnabled = false;
            }
            else
            {
                BtnUsed.IsEnabled = true;
                MIUsed.IsEnabled = true;
            }
        }

        #endregion

        #endregion

        #region Элементы формы

        #region Меню

        private void Menu_btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            //операция
            rb_Encryption.IsChecked = true;

            //способ шифрования
            cb_Algorithms.SelectedIndex = -1;
            cb_Algorithms_Border.Background = this.Background;

            //исходные
            tb_FileName_Source.Text = "";
            tb_SourceData.Text = "";
            tb_SourceData.FontSize = 12;

            //результат
            tb_FileName_Encrypted.Text = "";
            tb_EncryptedData.Text = "";
            tb_EncryptedData.FontSize = 12;

            //ключ
            tb_Key.Text = "";
            tb_Key_2.Text = "";
        }

        private void Menu_btn_FileSelection_Source_Click(object sender, RoutedEventArgs e)
        {

        }

        //открыть ключ

        private void Menu_btn_SaveFile_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File(tb_FileName_Source, tb_SourceData);
        }

        private void Menu_btn_SaveFileAs_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(cb_Algorithms, tb_FileName_Source, tb_SourceData, true);
        }

        private void Menu_btn_SaveFileAs_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(cb_Algorithms, tb_FileName_Encrypted, tb_EncryptedData, false);
        }

        //сохранить ключ

        private void Menu_btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Исходные данные

        private void Btn_FileSelection_Source_Click(object sender, RoutedEventArgs e)
        {
            File_Selection(tb_FileName_Source, tb_SourceData);
        }

        private void Btn_SaveFile_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File(tb_FileName_Source, tb_SourceData);
        }

        private void Btn_SaveFileAs_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(cb_Algorithms, tb_FileName_Source, tb_SourceData, true);
        }

        private void Tb_FileName_Source_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changed_File_Name_TB(tb_FileName_Source, btn_SaveFile_Source, menu_btn_SaveFile);
        }

        private void Btn_Clear_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Clear_tb(tb_SourceData);
        }

        private void Btn_Increase_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Font_Size(tb_SourceData, true);
        }

        private void Btn_Reduce_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Font_Size(tb_SourceData, false);
        }

        #endregion

        #region Результат

        private void Btn_SaveFileAs_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(cb_Algorithms, tb_FileName_Encrypted, tb_EncryptedData, false);
        }

        private void Btn_Clear_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Clear_tb(tb_EncryptedData);
        }

        private void Btn_Increase_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Font_Size(tb_EncryptedData, true);
        }

        private void Btn_Reduce_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Font_Size(tb_EncryptedData, false);
        }

        #endregion

        #region Ключ

        private void Btn_FileSelection_Key_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_SaveFileAs_Key_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Without_a_Space(object sender, KeyEventArgs e)
        {
            /*if (e.Key == Key.Space)
            {
                e.Handled = true;
            }*/
        }

        #endregion

        #endregion

        private void Btn_ExecuteOperation_Click(object sender, RoutedEventArgs e)
        {
            switch (cb_Algorithms.SelectedIndex)
            {
                case -1: MessageBox.Show("Выберите способ шифрования"); cb_Algorithms_Border.Background = Brushes.Red; break;
                case 0: Transposition_Cipher(); break;
                case 1: Monoalphabetic_Cipher(); break;
                case 2: Polyalphabetic_Cipher(); break;
                case 3: XOR_Cipher(); break;
                case 4: Vernam_Cipher(); break;
                case 5: RSA_Cipher(); break;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) //горячие клавиши
        {
            /*switch (e.Key)
            {
                case Key.F1: New_Game(); break; //Новая игра
                case Key.F2: Beginner_Mode(); break; //Новичок
                case Key.F3: Enthusiast_Mode(); break; //Любитель
                case Key.F4: Professional_Mode(); break; //Профессионал
                case Key.F5: Transition_Special_Window(); break; //Особый
                case Key.F6: Help(); break; //Как играть
                case Key.F7: Transition_Records_Window(); break;  //Рекорды
                case Key.F12: this.Close(); break; //Выход
                case Key.OemMinus: Game_Size_Switch(false); break; //Уменьшение размера игры 
                case Key.OemPlus: Game_Size_Switch(true); break; //Увеличение размера игры
            }*/
        }

        private void Cb_Algorithms_SelectionChanged(object sender, SelectionChangedEventArgs e) //изменение цвета
        {
            cb_Algorithms_Border.Background = this.Background;
        }
    }
}