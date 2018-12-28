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
using System.Data.SQLite;
using System.Data;
using Microsoft.Win32;

namespace S1WP
{
    /// <summary>
    /// Логика взаимодействия для Records_Window.xaml
    /// </summary>
    public partial class Records_Window : Window
    {
        public string FullPath;
        public string RecGameMode;
        public static DataTable data = new DataTable();
        public int[] Record_Array = new int[10];
        int t = 0;

        public Records_Window()
        {
            InitializeComponent();
            Table_Records.IsEnabled=false;
            switch (MainWindow.ModeTag)
            {
                case 0: RB_BeginnerMode.IsChecked = true; break;
                case 1: RB_BeginnerMode.IsChecked = true; break;
                case 2: RB_EnthusiastMode.IsChecked = true; break;
                case 3: RB_ProfessionalMode.IsChecked = true; break;
            }

            if (MainWindow.WinOrLose == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (MainWindow.timesec <= Record_Array[i])
                    {
                        t = i;
                        if (MessageBox.Show("ПОЗДРАВЛЯЕМ! Вы побили рекорд. Хотите внести своё имя в таблицу рекордов?", "Вы побили рекорд!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            if (Nick_Name.NNNickName == "" || Nick_Name.NNNickName == null)
                            {
                                Input_Name();
                            }
                            else
                            {
                                if (MessageBox.Show("Вы уже указывали своё имя. Хотите использовать его сново?", "Использовать старое имя?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                                    CheckTableHit();
                                else
                                {
                                    Input_Name();
                                }
                            }
                        }
                        else
                        {
                            MainWindow.WinOrLose = false;
                        }
                        break;
                    }
                }
            }
        }

        private void CheckTableHit()
        {
            for (int i = 10; i > t; i--)
            {
                try
                {
                    data.Rows[i][1] = Convert.ToString(data.Rows[i - 1][1]);
                    data.Rows[i][2] = Convert.ToString(data.Rows[i - 1][2]);
                }
                catch { }
            }

            data.Rows[t][1]=Convert.ToString(Nick_Name.NNNickName);
            data.Rows[t][2] = Convert.ToString(MainWindow.timesec);

            MainWindow.WinOrLose = false;

            UpdateToTable();
        }

        public void UpdateToTable()
        {
            SQLiteConnection connection = new SQLiteConnection(FullPath);
            connection.Open();
            for (int i = 0; i < 10; i++)
            {
                SQLiteParameter[] sQLiteParameter = new SQLiteParameter[2];
                sQLiteParameter[0] = new SQLiteParameter("@Name", data.Rows[i][1].ToString());
                sQLiteParameter[1] = new SQLiteParameter("@Record", data.Rows[i][2].ToString());
                string sql = "Update " + RecGameMode + " set Name = @Name, Record = @Record where ID = '" + (i+1) + "';";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.Parameters.AddRange(sQLiteParameter);
                SQLiteDataReader reader = command.ExecuteReader();
            }
        }

        public void selectALLData()
        {
            try
            {
                data = null;
                FullPath = "Data Source = Records.db;";
                SQLiteConnection connection = new SQLiteConnection(FullPath);
                connection.Open();
                string sql = "select * from " + RecGameMode + ";";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
                data = new DataTable(RecGameMode);
                dataAdapter.Fill(data);
                data.Columns["ID"].ColumnName = "№";
                data.Columns["Name"].ColumnName = "Имя";
                data.Columns["Record"].ColumnName = "Рекорд";
                Table_Records.ItemsSource = data.DefaultView;
                for (int i = 0; i < 10; i++)
                {
                    Record_Array[i] = Convert.ToInt32(data.Rows[i][2]);
                }
            }
            catch
            {
                MessageBox.Show("Не найдена база данных!");
            }
        }

        void Input_Name()
        {
            Transition_Nick_Name_Window();
            if (Nick_Name.NNNickName != "")
                CheckTableHit();
        }

        public void Transition_Nick_Name_Window()
        {
            Nick_Name taskWindow = new Nick_Name();
            taskWindow.ShowDialog();
        }

        private void RB_BeginnerMode_Checked(object sender, RoutedEventArgs e)
        {
            RecGameMode = "Beginner";
            selectALLData();
        }

        private void RB_EnthusiastMode_Checked(object sender, RoutedEventArgs e)
        {
            RecGameMode = "Enthusiast";
            selectALLData();
        }

        private void RB_ProfessionalMode_Checked(object sender, RoutedEventArgs e)
        {
            RecGameMode = "Professional";
            selectALLData();
        }
    }
}