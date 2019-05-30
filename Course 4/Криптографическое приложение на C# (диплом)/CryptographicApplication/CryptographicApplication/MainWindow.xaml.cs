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
using System.Security.Cryptography;

namespace CryptographicApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        #region Переменные

        public char[] lang = "АБВГДЕЁЖЗИЙ ЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}\\".ToCharArray();
        Transposition t;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            rb_Encryption.IsChecked = true;
            t = new Transposition();
        }

        #region Функционал

        #region Алгоритмы шифрования и дешифровки

        public void Transposition_Cipher()
        {
            t.SetKey(tb_Key.Text);

            if (rb_Encryption.IsChecked == true)
            {
                tb_EncryptedData.Text = t.Encrypt(tb_SourceData.Text);
            }
            else
            {
                tb_EncryptedData.Text = t.Decrypt(tb_SourceData.Text);
            }
        }

        public string Monoalphabetic_Cipher()
        {
            StringBuilder code = new StringBuilder();
            string sourcetext = tb_SourceData.Text;
            int shift = Convert.ToInt32(tb_Key.Text);

            for (int i = 0; i < sourcetext.Length; i++)
            {
                //поиск символа в алфавите
                for (int j = 0; j < lang.Length; j++)
                {
                    //если символ найден
                    if (sourcetext[i] == lang[j])
                    {
                        if (rb_Encryption.IsChecked == true) //Шифрование
                        {
                            code.Append(lang[(j + shift) % lang.Length]);
                        }
                        else if (rb_Decryption.IsChecked == true) //Дешифрование
                        {
                            code.Append(lang[(j - shift + lang.Length) % lang.Length]);
                        }
                        break;
                    }
                    //если символ не найден
                    else if (j == lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                    }
                }
            }

            return code.ToString();
        }

        public string Polyalphabetic_Cipher()
        {
            StringBuilder code = new StringBuilder();
            string sourcetext = tb_SourceData.Text;
            string key = tb_Key.Text;
            int[] key_id = new int[key.Length];
            int t = 0;

            //поиск индексов букв ключа
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < lang.Length; j++)
                {
                    if (key[i] == lang[j])
                    {
                        key_id[i] = j;
                        break;
                    }
                }    
            }

            for (int i = 0; i < sourcetext.Length; i++)
            {
                //поиск символа в алфавите
                for (int j = 0; j < lang.Length; j++)
                {
                    //если символ найден
                    if (sourcetext[i] == lang[j])
                    {
                        if (rb_Encryption.IsChecked == true) //Шифрование 
                        {
                            if (t > key.Length - 1)
                            {
                                t = 0;
                            }
                            code.Append(lang[(j + key_id[t]) % lang.Length]);
                            t++;
                        }
                        else if (rb_Decryption.IsChecked == true) //Дешифрование
                        {
                            if (t > key.Length - 1)
                            {
                                t = 0;
                            }
                            code.Append(lang[(j + lang.Length - key_id[t]) % lang.Length]);
                            t++;
                        }
                        break;
                    }
                    //если символ не найден
                    else if (j == lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                        t++;
                    }
                }
            }

            return code.ToString();
        }

        public string Vernam_Cipher()
        {
            StringBuilder code = new StringBuilder();
            string sourcetext = tb_SourceData.Text;
            string key = tb_Key.Text;
            int[] key_id = new int[key.Length];

            //поиск индексов букв ключа
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < lang.Length; j++)
                {
                    if (key[i] == lang[j])
                    {
                        key_id[i] = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < sourcetext.Length; i++)
            {
                //поиск символа в алфавите
                for (int j = 0; j < lang.Length; j++)
                {
                    //если символ найден
                    if (sourcetext[i] == lang[j])
                    {
                        code.Append(lang[(j ^ key_id[i] % 32) % lang.Length]);
                        break;
                    }
                    //если символ не найден
                    else if (j == lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                    }
                }
            }

            return code.ToString();
        }

        public string XOR_Cipher()
        {
            StringBuilder code = new StringBuilder();
            string sourcetext = tb_SourceData.Text;
            string key = tb_Key.Text;
            int[] key_id = new int[key.Length];
            int t = 0;

            //поиск индексов букв ключа
            for (int i = 0; i < key.Length; i++)
            {
                for (int j = 0; j < lang.Length; j++)
                {
                    if (key[i] == lang[j])
                    {
                        key_id[i] = j;
                        break;
                    }
                }
            }

            for (int i = 0; i < sourcetext.Length; i++)
            {
                //поиск символа в алфавите
                for (int j = 0; j < lang.Length; j++)
                {
                    //если символ найден
                    if (sourcetext[i] == lang[j])
                    {
                        if (t > key.Length - 1)
                        {
                            t = 0;
                        }
                        code.Append(lang[(j ^ key_id[t] % 32) % lang.Length]);
                        t++;
                        break;
                    }
                    //если символ не найден
                    else if (j == lang.Length - 1)
                    {
                        code.Append(sourcetext[i]);
                        t++;
                    }
                }
            }

            return code.ToString();
        }

        #endregion

        #region Прочие функции

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

        public void Font_Size(bool a, bool b)
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

        public void Save_File(TextBox localFileName, TextBox TextToSave)
        {
            File.WriteAllText(localFileName.Text, TextToSave.Text, Encoding.Default);
        }

        public void Save_File_As(TextBox NewFileName, TextBox TextToSave)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();

            saveFileDlg.DefaultExt = ".txt";
            saveFileDlg.Filter = "Текстовый документ (.txt) | * .txt";
            saveFileDlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //saveFileDlg.FileName = "Зашифрованный файл";


            Nullable<bool> result = saveFileDlg.ShowDialog();

            if (result == true)
            {
                NewFileName.Text = saveFileDlg.FileName;
                File.WriteAllText(saveFileDlg.FileName, TextToSave.Text, Encoding.Default);
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
            Save_File(tb_FileName_Source, tb_SourceData);
        }

        private void Btn_SaveFileAs_Source_Click(object sender, RoutedEventArgs e)
        {
            Save_File_As(tb_FileName_Source, tb_SourceData);
        }

        private void Tb_FileName_Source_TextChanged(object sender, TextChangedEventArgs e)
        {
            Changed_File_Name_TB(tb_FileName_Source, btn_SaveFile_Source, menu_btn_SaveFile);
        }

        private void Btn_Clear_Source_Click(object sender, RoutedEventArgs e)
        {
            Clear(true);
        }

        private void Btn_Increase_Source_Click(object sender, RoutedEventArgs e)
        {
            Font_Size(true, true);
        }

        private void Btn_Reduce_Source_Click(object sender, RoutedEventArgs e)
        {
            Font_Size(true, false);
        }

        #endregion

        #region Результат

        private void Btn_SaveFileAs_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            Save_File_As(tb_FileName_Encrypted, tb_EncryptedData);
        }

        private void Btn_Clear_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            Clear(false);
        }

        private void Btn_Increase_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            Font_Size(false, true);
        }

        private void Btn_Reduce_Encrypted_Click(object sender, RoutedEventArgs e)
        {
            Font_Size(false, false);
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
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        #endregion

        #endregion

        private void Btn_ExecuteOperation_Click(object sender, RoutedEventArgs e)
        {
            switch (cb_Algorithms.SelectedIndex)
            {
                case -1: MessageBox.Show("Выберите метод шифрования"); break;
                case 0: Transposition_Cipher(); break;
                case 1: tb_EncryptedData.Text = Monoalphabetic_Cipher(); break;
                case 2: tb_EncryptedData.Text = Polyalphabetic_Cipher(); break;
                case 3: tb_EncryptedData.Text = Vernam_Cipher(); break;
                case 4: tb_EncryptedData.Text = XOR_Cipher(); break;
                case 5: MessageBox.Show("Rivest, Shamir, Adleman (RSA)"); break;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e) //Горячие клавиши
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
    }
}