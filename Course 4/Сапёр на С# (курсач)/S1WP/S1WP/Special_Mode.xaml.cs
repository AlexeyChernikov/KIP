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
    /// Логика взаимодействия для Special_Mode.xaml
    /// </summary>
    public partial class Special_Mode : Window
    {
        public Special_Mode()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            int h, w;
            if (Special_Height.Text == ""  || Special_Weight.Text == "" || Special_Mine.Text == "" 
                || Special_Height.Text == "0" || Special_Weight.Text == "0" || (h = Convert.ToInt32(Special_Height.Text)) > 20
                || (w = Convert.ToInt32(Special_Weight.Text)) < 9 || (w = Convert.ToInt32(Special_Weight.Text)) > 40)
            {
                //Ничего
            }
            else
            {
                MainWindow.y = Convert.ToInt32(Special_Height.Text);
                MainWindow.x = Convert.ToInt32(Special_Weight.Text);
                MainWindow.CountMine = Convert.ToInt32(Special_Mine.Text);
                if (MainWindow.x < 9)
                    MainWindow.x = 9;
                if (MainWindow.CountMine >= (MainWindow.x * MainWindow.y))
                    MainWindow.CountMine = (MainWindow.x * MainWindow.y) - 1;
                (this.Owner as MainWindow).New_Game();
                this.Close();
            }
        }

        void Only_Number(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void Without_a_Space(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Fill_TBH(object sender, TextChangedEventArgs e)
        {
            int h = 0;
            if (Special_Height.Text == "" || (h = Convert.ToInt32(Special_Height.Text)) > 20)
            {
                Special_Height.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else if (Special_Height.Text == "0")
            {
                Special_Height.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
                Special_Height.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
        }

        private void Fill_TBW(object sender, TextChangedEventArgs e)
        {
            int w = 0;
            if (Special_Weight.Text == "" || (w = Convert.ToInt32(Special_Weight.Text)) < 9 
                || (w = Convert.ToInt32(Special_Weight.Text)) > 40)
            {
                Special_Weight.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else if (Special_Weight.Text == "0")
            {
                Special_Weight.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
                Special_Weight.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
        }

        private void Fill_TBM(object sender, TextChangedEventArgs e)
        {
            if (Special_Mine.Text == "")
            {
                Special_Mine.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else
                Special_Mine.BorderBrush = new SolidColorBrush(Color.FromRgb(171, 173, 179));
        }

    }
}
