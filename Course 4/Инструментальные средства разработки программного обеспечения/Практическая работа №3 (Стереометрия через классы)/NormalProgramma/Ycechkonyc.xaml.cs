using System;

using System.Windows;
using System.Windows.Controls;


namespace NormalProgramma
{
    /// <summary>
    /// Логика взаимодействия для Ycechkonyc.xaml
    /// </summary>
    public partial class Ycechkonyc : Window
    {
        public Ycechkonyc()
        {
            InitializeComponent();
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
        
        private void txt_4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_4.Text.Length >= 15)
            {
                MessageBox.Show("Переполнение данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return;
            }
            ypr();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow MainWindow_obj = new MainWindow();
            MainWindow_obj.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow MainWindow_obj = new MainWindow();
            MainWindow_obj.Show();
        }

        private void clear()
        {
            txt_5.Clear();
            txt_6.Clear();
            txt_7.Clear();
            txt_8.Clear();
            txt_9.Clear();
        }
        private void ypr()
        {
            double r = 0, h = 0, l = 0, R = 0;
            clear();

            if (Double.TryParse(txt_1.Text, out R))
            {
                Class.Ykonus yko = new Class.Ykonus(R);
                txt_5.Text = Convert.ToString(yko.BigSOsn());
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
                txt_5.Text = "";
            }


            if (Double.TryParse(txt_2.Text, out r))
            {
                Class.Ykonus yko = new Class.Ykonus(r,"");
                txt_6.Text = Convert.ToString(yko.SmalOsn());
            }
            else if (txt_2.Text == "")
            {
                
            }
            else if (txt_2.Text != "" || txt_2.Text == "0." || txt_2.Text == "0,")
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_2.Text = txt_2.Text.Substring(0, txt_2.Text.Length - 1);
                txt_2.Select(txt_2.Text.Length, 0);
                return;
            }
            else
            {
                txt_6.Text = "";
            }


            if (Double.TryParse(txt_3.Text, out h))
            {
                if (Double.TryParse(txt_2.Text, out r) && Double.TryParse(txt_1.Text, out R))
                {
                    Class.Ykonus yko = new Class.Ykonus(r,R,h);
                    txt_8.Text = Convert.ToString(yko.Volume());
                }
                else
                {
                    
                }
            }
            else if (txt_3.Text == "")
            {
                
            }
            else if (txt_3.Text != "" || txt_3.Text == "0." || txt_3.Text == "0,")
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_3.Text = txt_3.Text.Substring(0, txt_3.Text.Length - 1);
                txt_3.Select(txt_3.Text.Length, 0);
                return;
            }
            else
            {
                txt_8.Text = "";
            }

            if (Double.TryParse(txt_4.Text, out l))
            {
                if (Double.TryParse(txt_2.Text, out r) && Double.TryParse(txt_1.Text, out R))
                {

                    Class.Ykonus yko = new Class.Ykonus(l, r, R,"");
                    txt_7.Text = Convert.ToString(yko.SqrALL());
                    txt_9.Text = Convert.ToString(yko.SqrBock());
                }
                else
                {
                    
                }
            }
            else if (txt_4.Text == "")
            {
                

            }
            else if (txt_4.Text != "" || txt_4.Text == "0.")
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_4.Text = txt_4.Text.Substring(0, txt_4.Text.Length - 1);
                txt_4.Select(txt_4.Text.Length, 0);
                return;
            }
            else
            {
                txt_7.Text = "";
                txt_9.Text = "";

            }
        }

    }
}
