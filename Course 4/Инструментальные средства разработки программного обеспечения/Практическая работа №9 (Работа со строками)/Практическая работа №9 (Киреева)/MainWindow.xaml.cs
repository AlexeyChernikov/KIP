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

namespace Практическая_работа__9__Киреева_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int n = 0, m = 0;

        public MainWindow()
        {
            InitializeComponent();
            Operation1.IsChecked = true;
        }

        void All_Operations_List()
        {
            switch (n)
            {
                case 0: Perform_Operation1(); break;
                case 1: Perform_Operation2(); break;
                case 2: Perform_Operation3(); break;
                case 3: Perform_Operation4(); break;
                case 4: Perform_Operation5(); break;
                case 5: Perform_Operation6(); break;
                case 6: Perform_Operation7(); break;
                case 7: Perform_Operation8(); break;
                case 8: Perform_Operation9(); break;
                case 9: Perform_Operation10(); break;
                case 10: Perform_Operation11(); break;
                case 11: Perform_Operation12(); break;
                case 12: Perform_Operation13(); break;
            }
        }

        void All_Elements_List()
        {
            switch (m)
            {
                case 0: Elements_Operation1(); break;
                case 1: Elements_Operation2(); break;
                case 2: Elements_Operation3(); break;
                case 3: Elements_Operation4(); break;
                case 4: Elements_Operation5(); break;
                case 5: Elements_Operation6(); break;
                case 6: Elements_Operation7(); break;
                case 7: Elements_Operation8(); break;
                case 8: Elements_Operation9(); break;
                case 9: Elements_Operation10(); break;
                case 10: Elements_Operation11(); break;
                case 11: Elements_Operation12(); break;
                case 12: Elements_Operation13(); break;
            }
            TB1.Text = TB2.Text = TB3.Text = "";
        }

        private void Elements_Operation1()
        {
            L1.Content = "Поиск слова:";
            L2.Content = "Текст поиска:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "string str1 = TB1.Text;\n" +
            "string str2 = TB2.Text;\n" +
            "if (str2.Contains(str1))\n" +
                "TB3.Text = \"Найдено\";\n" +
            "else\n" +
                "TB3.Text = \"Не найдено\";\n";
        }

        private void Elements_Operation2()
        {
            L1.Content = "Строка 1:";
            L2.Content = "Строка 2:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "string str1 = TB1.Text;\n" +
            "string str2 = TB2.Text;\n" +
            "TB3.Text = Convert.ToString(str1.EndsWith(str2));";
        }

        private void Elements_Operation3()
        {
            L1.Content = "Строка 1:";
            L2.Content = "Строка 2:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "try\n" +
            "{\n" +
                "string str1 = TB1.Text;\n" +
                "string str2 = TB2.Text;\n" +
                "string str3 = TB3.Text;\n" +
                "TB3.Text = str1.Insert(Convert.ToInt32(str3), str2);\n" +
            "}\n" +
            "catch\n" +
            "{\n" +
                "TB3.Text = \"Ошибка!\";\n" +
            "}";
        }

        private void Elements_Operation4()
        {
            L1.Content = "Текст:";
            L2.Content = "Изменяемое слово:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "try {\n" +
            "string str1 = TB1.Text;\n" +
            "string str2 = TB2.Text;\n" +
            "string str3 = TB3.Text;\n" +
            "TB3.Text = str1.Replace(str2, str3);\n" +
            "catch {\n" +
            "TB3.Text = \"Ошибка!\";\n" +
            "}";
        }

        private void Elements_Operation5()
        {
            L1.Content = "Текст:";
            L2.Content = "Результат:";
            L3.Visibility = Visibility.Collapsed;
            TB3.Visibility = Visibility.Collapsed;
            TB4.Text = "string str1 = TB1.Text;\n" +
            "TB2.Text = str1.ToLower();";
        }

        private void Elements_Operation6()
        {
            L1.Content = "Строка 1:";
            L2.Content = "Строка 2:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "string str1 = TB1.Text;\n" +
            "string str2 = TB2.Text;\n" +
            "TB3.Text = string.Concat(str1, str2);";
        }

        private void Elements_Operation7()
        {
            L1.Content = "Число:";
            L2.Content = "Результат:";
            L3.Visibility = Visibility.Collapsed;
            TB3.Visibility = Visibility.Collapsed;
            TB4.Text = "try\n" +
            "{\n" +
                "string str1 = TB1.Text;\n" +
                "double strd1 = Convert.ToDouble(str1);\n" +
                "TB2.Text = String.Format(\"{0:C2}\", Convert.ToInt32(strd1)) + \"\\n\" + String.Format(\"{0:d}\", Convert.ToInt32(strd1)) + \"\\n\" + String.Format(\"{0:f}\", Convert.ToDouble(strd1));\n" +
            "}\n" +
            "catch\n" +
            "{\n" +
                "TB2.Text = \"Введите число!\";\n" +
            "}";
        }

        private void Elements_Operation8()
        {
            L1.Content = "Текст:";
            L2.Content = "Результат:";
            L3.Visibility = Visibility.Collapsed;
            TB3.Visibility = Visibility.Collapsed;
            TB4.Text = "TB2.Text = \"\";\n" +
            "string str1 = TB1.Text;\n" +
            "string[] words = str1.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);\n" +
            "foreach (string s in words)\n" +
            "{\n" +
                "TB2.Text += s + \"\\n\";\n" +
            "}";
        }

        private void Elements_Operation9()
        {
            L1.Content = "Текст:";
            L2.Content = "Результат:";
            L3.Visibility = Visibility.Collapsed;
            TB3.Visibility = Visibility.Collapsed;
            TB4.Text = "string str1 = TB1.Text;\n" +
            "TB2.Text = str1.ToUpper();";
        }

        private void Elements_Operation10()
        {
            L1.Content = "Текст:";
            L2.Content = "Искомое:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "string str1 = TB1.Text;\n" +
            "string str2 = TB2.Text;\n" +
            "if (str1.IndexOf(str2) != -1)\n" +
                "TB3.Text = Convert.ToString(str1.IndexOf(str2));\n" +
            "else\n" +
                "TB3.Text = \"Вхождений не найдено!\";";
        }

        private void Elements_Operation11()
        {
            L1.Content = "Текст:";
            L2.Content = "Искомое:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "string str1 = TB1.Text;\n" +
            "string str2 = TB2.Text;\n" +
            "if (str1.LastIndexOf(str2) != -1)\n" +
                "TB3.Text = Convert.ToString(str1.LastIndexOf(str2));\n" +
            "else\n" +
                "TB3.Text = \"Вхождений не найдено!\";";
        }

        private void Elements_Operation12()
        {
            L1.Content = "Текст:";
            L2.Content = "Обрезаемый символ:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "try\n" +
            "{\n" +
                "string str1 = TB1.Text;\n" +
                "string str2 = TB2.Text;\n" +
                "TB3.Text = str1.Trim(new char[] { Convert.ToChar(str2) });\n" +
            "}\n" +
            "catch\n" +
            "{\n" +
                "TB3.Text = \"Ошибка!\";\n" +
            "}";
        }

        private void Elements_Operation13()
        {
            L1.Content = "Текст:";
            L2.Content = "Сколько обрезать:";
            L3.Visibility = Visibility.Visible;
            TB3.Visibility = Visibility.Visible;
            TB4.Text = "try\n" +
            "{\n" +
                "string str1 = TB1.Text;\n" +
                "string str2 = TB2.Text;\n" +
                "TB3.Text = str1.Substring(Convert.ToInt32(str2));\n" +
            "}\n" +
            "catch\n" +
            "{\n" +
                "TB3.Text = \"Ошибка!\";\n" +
            "}";
        }

        private void Perform_Operation1()
        {
            string str1 = TB1.Text;
            string str2 = TB2.Text;
            if (str2.Contains(str1))
                TB3.Text = "Найдено";
            else
                TB3.Text = "Не найдено";
        }

        private void Perform_Operation2()
        {
            string str1 = TB1.Text;
            string str2 = TB2.Text;
            TB3.Text = Convert.ToString(str1.EndsWith(str2));
        }

        private void Perform_Operation3()
        {
            try
            {
                string str1 = TB1.Text;
                string str2 = TB2.Text;
                string str3 = TB3.Text;
                TB3.Text = str1.Insert(Convert.ToInt32(str3), str2);
            }
            catch
            {
                TB3.Text = "Ошибка!";
            }
        }

        private void Perform_Operation4()
        {
            try
            {
                string str1 = TB1.Text;
                string str2 = TB2.Text;
                string str3 = TB3.Text;
                TB3.Text = str1.Replace(str2, str3);
            }
            catch
            {
                TB3.Text = "Ошибка!";
            }
        }

        private void Perform_Operation5()
        {
            string str1 = TB1.Text;
            TB2.Text = str1.ToLower();
        }

        private void Perform_Operation6()
        {
            string str1 = TB1.Text;
            string str2 = TB2.Text;
            TB3.Text = String.Concat(str1, str2);
        }

        private void Perform_Operation7()
        {
            try
            {
                string str1 = TB1.Text;
                double strd1 = Convert.ToDouble(str1);
                TB2.Text = String.Format("{0:C2}", Convert.ToInt32(strd1)) + "\n" + String.Format("{0:d}", Convert.ToInt32(strd1)) + "\n" + String.Format("{0:f}", Convert.ToDouble(strd1));
            }
            catch
            {
                TB2.Text = "Введите число!";
            }
        }

        private void Perform_Operation8()
        {
            TB2.Text = "";
            string str1 = TB1.Text;
            string[] words = str1.Split(new char[] { ' ', ',', '.'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in words)
            {
                TB2.Text += s + "\n";
            }
        }

        private void Perform_Operation9()
        {
            string str1 = TB1.Text;
            TB2.Text = str1.ToUpper();
        }

        private void Perform_Operation10()
        {
            string str1 = TB1.Text;
            string str2 = TB2.Text;
            if (str1.IndexOf(str2) != -1)
                TB3.Text = Convert.ToString(str1.IndexOf(str2));
            else
                TB3.Text = "Вхождений не найдено!";
        }

        private void Perform_Operation11()
        {
            string str1 = TB1.Text;
            string str2 = TB2.Text;
            if (str1.LastIndexOf(str2) != -1)
                TB3.Text = Convert.ToString(str1.LastIndexOf(str2));
            else
                TB3.Text = "Вхождений не найдено!";
        }

        private void Perform_Operation12()
        {
            try
            {
                string str1 = TB1.Text;
                string str2 = TB2.Text;
                TB3.Text = str1.Trim(new char[] { Convert.ToChar(str2) });
            }
            catch
            {
                TB3.Text = "Ошибка!";
            }
        }

        private void Perform_Operation13()
        {
            try
            {
                string str1 = TB1.Text;
                string str2 = TB2.Text;
                TB3.Text = str1.Substring(Convert.ToInt32(str2));
            }
            catch
            {
                TB3.Text = "Ошибка!";
            }
        }

        private void Operation1_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 0;
            All_Elements_List();
        }

        private void Operation2_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 1;
            All_Elements_List();
        }

        private void Operation3_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 2;
            All_Elements_List();
        }

        private void Operation4_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 3;
            All_Elements_List();
        }

        private void Operation5_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 4;
            All_Elements_List();
        }

        private void Operation6_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 5;
            All_Elements_List();
        }

        private void Operation7_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 6;
            All_Elements_List();
        }

        private void Operation8_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 7;
            All_Elements_List();
        }

        private void Operation9_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 8;
            All_Elements_List();
        }

        private void Operation10_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 9;
            All_Elements_List();
        }

        private void Operation11_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 10;
            All_Elements_List();
        }

        private void Operation12_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 11;
            All_Elements_List();
        }

        private void Operation13_Checked(object sender, RoutedEventArgs e)
        {
            n = m = 12;
            All_Elements_List();
        }

        private void Perform_Button_Click(object sender, RoutedEventArgs e)
        {
            All_Operations_List();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
