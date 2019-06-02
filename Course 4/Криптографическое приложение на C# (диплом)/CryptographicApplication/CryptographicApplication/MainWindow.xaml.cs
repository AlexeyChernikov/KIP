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
using System.Numerics;
using System.Diagnostics;

namespace CryptographicApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        #region Переменные

        public char[] lang = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}\\".ToCharArray();
        Transposition trans_obj;
        Monoalphabetic mono_obj;
        Polyalphabetic poly_obj;
        XOR xor_obj;
        Vernam vernam_obj;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            rb_Encryption.IsChecked = true;
            trans_obj = new Transposition();
            mono_obj = new Monoalphabetic();
            poly_obj = new Polyalphabetic();
            xor_obj = new XOR();
            vernam_obj = new Vernam();
        }

        #region Функционал

        #region Алгоритмы шифрования и дешифровки

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
            long p = Convert.ToInt64(tb_Key.Text);
            long q = Convert.ToInt64(tb_Key_2.Text);

            if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
            {
                string sourcetext = tb_SourceData.Text;

                long n = p * q;
                long m = (p - 1) * (q - 1);
                long d = Calculate_d(m);
                long e_ = Calculate_e(d, m);

                List<string> result = RSA_Endoce(sourcetext, e_, n);

                MessageBox.Show(d.ToString());
                MessageBox.Show(n.ToString());

                /*StreamWriter sw = new StreamWriter("out1.txt");
                foreach (string item in result)
                    sw.WriteLine(item);
                sw.Close();

                Process.Start("out1.txt");*/
            }
            else
                MessageBox.Show("p или q - не простые числа!");
        }

        private bool IsTheNumberSimple(long n) //является ли число простым
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        private long Calculate_e(long d, long m) //вычисление открытой экспоненты
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }

        private long Calculate_d(long m) //вычисление закрытой экспоненты
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }

        private List<string> RSA_Endoce(string s, long e, long n) //шифрование
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(lang, s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        private string RSA_Dedoce(List<string> input, long d, long n) //дешифрование
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());

                result += lang[index].ToString();
            }

            return result;
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
    }
}