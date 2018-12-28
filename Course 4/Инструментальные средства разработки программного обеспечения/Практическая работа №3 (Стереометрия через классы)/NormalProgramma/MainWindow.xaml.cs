using System;

using System.Windows;


namespace NormalProgramma
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            int ind = Chose.SelectedIndex;
            switch(ind)
            {
                case 0: Shar objShar = new Shar();
                    this.Hide();
                    objShar.ShowDialog();
                    
                    break;
                case 1:
                    Konyc objKonyc = new Konyc();
                    this.Hide();
                    objKonyc.ShowDialog();

                    break;
                case 2:
                    Ycechkonyc objYcechkonyc = new Ycechkonyc();
                    this.Hide();
                    objYcechkonyc.ShowDialog();

                    break;
                case 3:
                    barrelxaml objbarrelxamlc = new barrelxaml();
                    this.Hide();
                    objbarrelxamlc.ShowDialog();
                    
                    break;

            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Выйти?","Выход", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                Environment.Exit(0);
                Application.Current.Shutdown();
            }
        }
    }
}
