using System;

using System.Windows;
using System.Windows.Controls;

namespace NormalProgramma
{
    /// <summary>
    /// Логика взаимодействия для Shar.xaml
    /// </summary>
    public partial class Shar : Window
    {
        public Shar()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double r = 0;
            if (txt_1.Text.Length >= 15)
            {
                MessageBox.Show("Переполнение данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_2.Text = "";
                txt_3.Text = "";
                return;
            }
            if (double.TryParse(txt_1.Text,out r))
            {
                Class.SharCLass shar = new Class.SharCLass(r);
                txt_2.Text="";
                txt_2.Text = Convert.ToString(shar.Volume());
                txt_3.Text = "";
                txt_3.Text = Convert.ToString(shar.Squre());

            }
            else if(txt_1.Text != ""||txt_1.Text=="0."||txt_1.Text=="0,")
            {

                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_1.Text = txt_1.Text.Substring(0, txt_1.Text.Length - 1);
                txt_1.Select(txt_1.Text.Length, 0);
                txt_2.Text = "";
                txt_3.Text = "";
            }
            else
            {
                txt_2.Text = "";
                txt_3.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow MainWindow_obj = new MainWindow();
            MainWindow_obj.Show();
        }




    }
}
