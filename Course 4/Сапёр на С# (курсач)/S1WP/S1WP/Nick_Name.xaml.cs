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
using System.Windows.Shapes;

namespace S1WP
{
    /// <summary>
    /// Логика взаимодействия для Nick_Name.xaml
    /// </summary>
    public partial class Nick_Name : Window
    {
        public static string NNNickName;

        public Nick_Name()
        {
            InitializeComponent();
            NNNickName = "";
            Nick_NameTB.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Nick_NameTB.Text != "")
            {
                NNNickName = Convert.ToString(Nick_NameTB.Text);
                this.Close();
            }
        }

        private void Without_a_Space(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (NNNickName == "")
            {
                if (MessageBox.Show("В случае закрытия этого окна ваш рекорд не будет записан. Вы действительно хотите закрыть окно?", "Закрыть окно?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MainWindow.WinOrLose = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void Nick_NameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Nick_NameTB.Text == "")
            {
                Nick_NameTB.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
                Nick_NameTB.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
        }
    }
}
