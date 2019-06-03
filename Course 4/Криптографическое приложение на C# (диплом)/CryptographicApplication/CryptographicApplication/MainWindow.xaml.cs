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
using System.Diagnostics;

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

        #region Элементы формы

        #region Меню

        private void Menu_btn_ExecuteOperation_Click(object sender, RoutedEventArgs e)
        {
            List_of_Operations_to_Perform();
        }

        private void Menu_btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Menu_btn_Key_Generation_Click(object sender, RoutedEventArgs e)
        {
            List_of_Key_Generation_Methods();
        }

        private void Menu_btn_FileSelection_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.File_Selection(tb_FileName_Source, tb_SourceData, tb_EncryptedData);
        }

        private void Menu_btn_FileSelection_Key_Click(object sender, RoutedEventArgs e)
        {
            func_obj.File_Selection(tb_Key);
        }

        private void Menu_btn_SaveFile_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File(tb_FileName_Source, tb_SourceData);
        }

        private void Menu_btn_SaveFileAs_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(tb_FileName_Source, tb_SourceData);
        }

        private void Menu_btn_SaveFileAs_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(cb_Algorithms, tb_EncryptedData, rb_Encryption, true);
        }

        private void Menu_btn_SaveFileAs_Key_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(cb_Algorithms, tb_Key, rb_Encryption, false);
        }

        private void Menu_btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Menu_btn_About_the_Program_Click(object sender, RoutedEventArgs e)
        {
            Calling_Help();
        }

        #endregion

        #region Исходные данные

        private void Btn_FileSelection_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.File_Selection(tb_FileName_Source, tb_SourceData, tb_EncryptedData);
        }

        private void Btn_SaveFile_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File(tb_FileName_Source, tb_SourceData);
        }

        private void Btn_SaveFileAs_Source_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(tb_FileName_Source, tb_SourceData);
        }

        private void Tb_FileName_Source_TextChanged(object sender, TextChangedEventArgs e)
        {
            func_obj.Changed_File_Name_TB(tb_FileName_Source, btn_SaveFile_Source, menu_btn_SaveFile);
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
            func_obj.Save_File_As(cb_Algorithms, tb_EncryptedData, rb_Encryption, true);
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
            func_obj.File_Selection(tb_Key);
        }

        private void Btn_SaveFileAs_Key_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Save_File_As(cb_Algorithms, tb_Key, rb_Encryption, false);
        }

        private void Btn_Clear_Key_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Clear_tb(tb_Key);
        }

        private void Btn_Increase_Key_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Font_Size(tb_Key, true);
        }

        private void Btn_Reduce_Key_Click(object sender, RoutedEventArgs e)
        {
            func_obj.Font_Size(tb_Key, false);
        }

        #endregion

        #region Прочее

        public void List_of_Operations_to_Perform() //меню, определяющее какой метод выполнять
        {
            switch (cb_Algorithms.SelectedIndex)
            {
                case -1: cb_Algorithms_Border.Background = Brushes.Red; break;
                case 0: Transposition_Cipher(); break;
                case 1: Monoalphabetic_Cipher(); break;
                case 2: Polyalphabetic_Cipher(); break;
                case 3: XOR_Cipher(); break;
                case 4: Vernam_Cipher(); break;
                case 5: RSA_Cipher(); break;
            }
        }

        public void List_of_Key_Generation_Methods () //меню, определяющее для какого метода генерировать ключ
        {
            switch (cb_Algorithms.SelectedIndex)
            {
                case 0: Transposition_Cipher(); break;
                case 1: tb_Key.Text = mono_obj.Rand_Key_Generation(); break;
                case 2: Polyalphabetic_Cipher(); break;
                case 3: XOR_Cipher(); break;
                case 4: tb_Key.Text = vernam_obj.Rand_Key_Generation(tb_SourceData.Text.Length); break;
                case 5: RSA_Cipher(); break;
            }
        }

        public void Calling_Help()
        {
            try
            {
                string commandText = "Help.chm";
                var proc = new Process();
                proc.StartInfo.FileName = commandText;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
            catch
            {
                MessageBox.Show("Не найден файл справки!");
            }
        }

        public void Refresh() //обновить всё
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
            tb_EncryptedData.Text = "";
            tb_EncryptedData.FontSize = 12;

            //ключ
            tb_Key.Text = "";
            tb_Key.FontSize = 12;
            tb_Key_2.Text = "";
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) //горячие клавиши
        {
            switch (e.Key)
            {
                case Key.F1: List_of_Operations_to_Perform(); break; //выполнить
                case Key.F2: Refresh(); break; //обновить
                case Key.F3: if (cb_Algorithms.SelectedIndex != -1) List_of_Key_Generation_Methods(); break; //сгенерировать ключ
                case Key.F4: func_obj.File_Selection(tb_FileName_Source, tb_SourceData, tb_EncryptedData); break; //открыть файл с исходным текстом
                case Key.F5: func_obj.File_Selection(tb_Key); break; //открыть файл с ключом
                case Key.F6: if (tb_FileName_Source.Text != "") func_obj.Save_File(tb_FileName_Source, tb_SourceData); break; //сохранить
                case Key.F7: func_obj.Save_File_As(tb_FileName_Source, tb_SourceData); break;  //сохранить исходный текст
                case Key.F8: func_obj.Save_File_As(cb_Algorithms, tb_EncryptedData, rb_Encryption, true); break;  //сохранить зашифрованный/дешифрованный текст
                case Key.F9: func_obj.Save_File_As(cb_Algorithms, tb_Key, rb_Encryption, false); break;  //сохранить ключ
                case Key.F11: Calling_Help(); break;  //о программе
                case Key.F12: this.Close(); break; //выход
            }
        }

        private void Cb_Algorithms_SelectionChanged(object sender, SelectionChangedEventArgs e) //изменения комбобокса
        {
            cb_Algorithms_Border.Background = this.Background;
            func_obj.Changed_CB(cb_Algorithms, btn_Key_Generation, menu_btn_Key_Generation); //разблокирует или блокирует кнопку "Сгенерировать ключ"
        }

        private void Rb_Encryption_Checked(object sender, RoutedEventArgs e)
        {
            menu_btn_SaveFileAs_Encrypted.Header = "Сохранить зашифрованный текст";
        }

        private void Rb_Decryption_Checked(object sender, RoutedEventArgs e)
        {
            menu_btn_SaveFileAs_Encrypted.Header = "Сохранить дешифрованный текст";
        }

        private void Btn_ExecuteOperation_Click(object sender, RoutedEventArgs e)
        {
            List_of_Operations_to_Perform();
        }

        private void Btn_Key_Generation_Click(object sender, RoutedEventArgs e)
        {
            List_of_Key_Generation_Methods();
        }

        #endregion

        #endregion
    }
}