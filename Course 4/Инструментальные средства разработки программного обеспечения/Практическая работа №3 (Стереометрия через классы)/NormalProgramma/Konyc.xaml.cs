using System;
using System.Windows;
using System.Windows.Controls;


namespace NormalProgramma
{
    /// <summary>
    /// Логика взаимодействия для Konyc.xaml
    /// </summary>
    public partial class Konyc : Window
    {
        public Konyc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow MainWindow_obj = new MainWindow();
            MainWindow_obj.Show();
        }



        private void txt_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_1.Text.Length >= 15)
            {
                MessageBox.Show("Переполнение данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return;
            }
            ypr();

        }

        private void txt_2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_2.Text.Length >= 15)
            {
                MessageBox.Show("Переполнение данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return;
            }
            ypr();
        }

        private void txt_3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_3.Text.Length >= 15)
            {
                MessageBox.Show("Переполнение данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return;
            }
            ypr();
        }



        private void clear()
        {
            txt_4.Clear();
            txt_5.Clear();
            txt_6.Clear();
            txt_7.Clear();
        }
    
        private void ypr()
        {
            double r = 0, h = 0;
            clear();
           

            if (Double.TryParse(txt_1.Text, out r))
            {
                Class.Konus Konus = new Class.Konus(r,h);
                txt_4.Text = Convert.ToString(Konus.SqureOsnova());

            }
            else if (txt_1.Text == "")
            {
                

            }
            else if (txt_1.Text != "" || txt_1.Text == "0." || txt_1.Text == "0,")
            {
 
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_1.Text = txt_1.Text.Substring(0, txt_1.Text.Length - 1);
                txt_1.Select(txt_1.Text.Length, 0);
                return;
            }
            else
            {

                txt_4.Text = "";
            }
            if (Double.TryParse(txt_2.Text, out h))
            {
                if (Double.TryParse(txt_1.Text, out r) && Double.TryParse(txt_2.Text, out h))
                {
                    Class.Konus Konus = new Class.Konus(r, h);
                    txt_7.Text = Convert.ToString(Konus.Volume());
                    txt_5.Text = Convert.ToString(Konus.SqureBock());
                    txt_6.Text = Convert.ToString(Konus.SqureMain());
                }
                else if (txt_1.Text == "" || txt_2.Text == "")
                {
                    
                }
            }
            else if(txt_2.Text=="") 
            {
                
            }
            else if (txt_2.Text != "" || txt_2.Text == "0." || txt_2.Text == "0,")
            {

                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_2.Text = txt_2.Text.Substring(0, txt_2.Text.Length - 1);
                txt_2.Select(txt_2.Text.Length, 0);
                return;
            }
        }
    }
}
