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
using System.Collections;
using System.Windows.Threading;

namespace S1WP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public enum TypeButton
    {
        Mine,
        Flag,
        Number,
        Emotion
    }

    public partial class MainWindow : Window
    {

        #region Переменные

        public static int x = 9, y = 9, CountMine = 10, ModeTag = 1, timesec = 0;
        static int CountFlag = CountMine, ActualStep = 0;
        public static bool WinOrLose = false;
        static bool result = false;
        int[,] field = new int[x, y];
        int HSize = 20, WSize = 20, FSize = 12, SBSize = 40, TBWSize = 60, TBFSize = 20, GSS = 0;
        Button[] ButtonList = new Button[x * y];
        BitArray GameArray= new BitArray(x * y);
        Random rnd = new Random();
        DispatcherTimer timer = null;
        Uri uriMine = new Uri("pack://application:,,/Mine.png");
        Uri uriFlag = new Uri("pack://application:,,/Flag.png");
        Uri uriEmotion1 = new Uri("pack://application:,,/Emotion1.png");
        Uri uriEmotion2 = new Uri("pack://application:,,/Emotion2.png");
        Uri uriEmotion3 = new Uri("pack://application:,,/Emotion3.png");

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Installation_Mine();
            RB_100.IsChecked = true;
        }

        #region Игра

        void Installation_Mine(bool breaks = false, int count = 0)
        {
            SetButton(Smile, TypeButton.Emotion);
            timer = new DispatcherTimer();
            timesec = 0;
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0 ,0 , 0, 1000);
            TimerTB.Text = Convert.ToString(timesec);
            result = false;
            CountFlag = CountMine;
            ActualStep = 0;
            CountFlagTB.Text = Convert.ToString(CountFlag);
            Minefield.Width = HSize * x;
            Minefield.Height = WSize * y;
            for (int i = 0; i < GameArray.Length; i++)
            {
                if (count == CountMine)
                    break;
                if (!GameArray[i])
                    GameArray[i] = rnd.Next(0, 1000) < 50 && rnd.Next(0, 1000) > 800 ? true : false;
                else
                    continue;
                if (GameArray[i])
                    count++;
            }
            if (count < CountMine)
                Installation_Mine(true, count);
            if (breaks)
                return;
            Window_Size();
            Creation_Minefield(x * y);

        }

        private void Creation_Minefield(int count)
        {
            Minefield.Children.Clear();
            for (int i = 0; i < count; i++)
            {
                Button t = new Button()
                {
                    FontSize = FSize,
                    Width = WSize,
                    Height = HSize,
                    Tag = i
                };
                t.Click += new RoutedEventHandler(button_Click);
                t.MouseRightButtonUp += new MouseButtonEventHandler(rightbutton_Click);
                Minefield.Children.Add(t);
                ButtonList[i] = t;
            }
        }

        void rightbutton_Click(object sender, MouseButtonEventArgs e)
        {
            if (result == false)
            {
                timer.Start();
                Button button = (Button)sender;
                int index = (int)button.Tag;
                if (button.Content == null && CountFlag > 0)
                {
                    SetButton(button, TypeButton.Flag);
                    CountFlag--;
                    CountFlagTB.Text = Convert.ToString(CountFlag);
                }
                else if (button.Content!=null)
                {
                    button.Content = null;
                    CountFlag++;
                    CountFlagTB.Text = Convert.ToString(CountFlag);
                }
            }
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            if (result == false)
            {
                Button button = (Button)sender;
                int index = (int)button.Tag;
                if (GameArray[index]) //Lose
                {
                    for (int i = 0; i < GameArray.Length; i++)
                        if (GameArray[i])
                            SetButton(ButtonList[i], TypeButton.Mine);
                        SetButton(ButtonList[index], TypeButton.Mine, 1);
                    result = true;
                    timer.Stop();
                    SetButton(Smile, TypeButton.Emotion, 2);
                }
                else
                {
                    timer.Start();
                    Step(index);
                    if (ActualStep == x * y - CountMine) //Win
                    {
                        if (ModeTag != 0)
                            WinOrLose = true;
                        timer.Stop();
                        result = true;
                        for (int i = 0; i < GameArray.Length; i++)
                            if (GameArray[i])
                                SetButton(ButtonList[i], TypeButton.Flag);
                        CountFlag = 0;
                        CountFlagTB.Text = Convert.ToString(CountFlag);
                        SetButton(Smile, TypeButton.Emotion, 1);
                        if (ModeTag != 0)
                        {
                            Transition_Records_Window();
                        }
                    }
                }
            }
        }

        void SetButton(Button button, TypeButton type, int number = 0)
        {
            BitmapImage bitmap = new BitmapImage();

            if (type == TypeButton.Emotion)
            {
                switch (number)
                {
                    case 0: bitmap = new BitmapImage(uriEmotion1); break;
                    case 1: bitmap = new BitmapImage(uriEmotion2); break;
                    case 2: bitmap = new BitmapImage(uriEmotion3); break;
                }
            }

            if (type == TypeButton.Mine)
            {
                bitmap = new BitmapImage(uriMine);
                if (number == 1)
                {
                    button.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    button.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
                else
                {
                    button.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
                    button.BorderBrush = new SolidColorBrush(Color.FromRgb(200, 200, 200));
                }
            }

            if (type == TypeButton.Flag)
                bitmap = new BitmapImage(uriFlag);

            if (type != TypeButton.Number)
            {
                Image img = new Image()
                {
                    Source = bitmap
                };
                Grid grid = new Grid();
                grid.Children.Add(img);
                button.Content = grid;
            }

            if (type == TypeButton.Number)
            {
                if (button.Content != null)
                {
                    CountFlag++;
                    CountFlagTB.Text = Convert.ToString(CountFlag);
                }
                if (number == 0)
                {
                    button.Content = null;
                }
                else
                    button.Content = number;
                button.IsEnabled = false;
            }
        }

        void Step(int index)
        {
            int[] t = new int[8];
            int row = index / x;
            int column = row * x - index;

            t[0] = x * (row - 1) + (index % x);
            t[1] = x * (row + 1) + (index % x);
            t[2] = t[0] + 1;
            t[3] = t[0] - 1;
            t[4] = t[1] + 1;
            t[5] = t[1] - 1;
            t[6] = index + 1;
            t[7] = index - 1;

            int count = 0;
            for (int i = 0; i < t.Length; i++)
                if (ContainsIndex(t[i], index, row, column))
                    if (GameArray[t[i]])
                        count++;

            if (count == 0)
            {
                ButtonList[index].IsEnabled = false;
                SetButton(ButtonList[index], TypeButton.Number);
                ActualStep += 1;
                for (int i = 0; i < t.Length; i++)
                    if (ContainsIndex(t[i], index, row, column))
                        if (ButtonList[t[i]].IsEnabled)
                            Step(t[i]);
            }
            else
            {
                SetButton(ButtonList[index], TypeButton.Number, count);
                switch (count)
                {
                    case 1: ButtonList[index].Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255)); break;
                    case 2: ButtonList[index].Foreground = new SolidColorBrush(Color.FromRgb(0, 82, 0)); break;
                    case 3: ButtonList[index].Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0)); break;
                    case 4: ButtonList[index].Foreground = new SolidColorBrush(Color.FromRgb(139, 0, 255)); break;
                    case 5: ButtonList[index].Foreground = new SolidColorBrush(Color.FromRgb(139, 0, 0)); break;
                    case 6: ButtonList[index].Foreground = new SolidColorBrush(Color.FromRgb(8, 232, 222)); break;
                    case 7: ButtonList[index].Foreground = new SolidColorBrush(Color.FromRgb(0, 5, 71)); break;
                    case 8: ButtonList[index].Foreground = new SolidColorBrush(Color.FromRgb(87, 87, 87)); break;
                }
                ActualStep += 1;
            }
        }

        bool ContainsIndex(int index, int baseInd, int baseRow, int baseCol)
        {
            if (index >= 0 && index < GameArray.Length)
            {
                int row = index / x;
                int column = row * x - index;
                if (Math.Abs(baseRow - row) > 1)
                    return false;
                if (Math.Abs(baseCol - column) > 1)
                    return false;
                return true;
            }
            else
                return false;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            timesec++;
            TimerTB.Text = Convert.ToString(timesec);
        }

        public void New_Game()
        {
            WinOrLose = false;
            timer.Stop();
            GameArray = null;
            GameArray = new BitArray(x * y);
            ButtonList = null;
            ButtonList = new Button[x * y];
            Installation_Mine();
        }

        void Window_Size()
        {
            this.Width = (Minefield.Width = WSize * x) + 36;
            this.Height = (Minefield.Height = HSize * y) + 94 + SBSize;
            Main_Menu.Width = this.Width;
            Smile.Height = Smile.Width = SBSize;
            TimerTB.Width = CountFlagTB.Width = TBWSize;
            TimerTB.Height = CountFlagTB.Height = SBSize;
            TimerTB.FontSize = CountFlagTB.FontSize = TBFSize;
            Thickness positionDown = new Thickness(10, (44+SBSize), 0, 0);
            Thickness positionRight = new Thickness((this.Width - TBWSize - 26), 33, 0, 0);
            Minefield.Margin = positionDown;
            TimerTB.Margin = positionRight;
        }

        private void Beginner_Mode()
        {
            ModeTag = 1;
            x = 9;
            y = 9;
            CountMine = 10;
            New_Game();
        }

        private void Enthusiast_Mode()
        {
            ModeTag = 2;
            x = 16;
            y = 16;
            CountMine = 40;
            New_Game();
        }

        private void Professional_Mode()
        {
            ModeTag = 3;
            x = 30;
            y = 16;
            CountMine = 99;
            New_Game();
        }

        private void Transition_Records_Window()
        {
            Records_Window taskWindow = new Records_Window();
            taskWindow.Owner = this;
            taskWindow.ShowDialog();
        }

        private void Transition_Special_Window()
        {
            ModeTag = 0;
            Special_Mode taskWindow = new Special_Mode();
            taskWindow.Owner = this;
            taskWindow.ShowDialog();
        }

        private void MineField_Elements_Size()
        {
            Minefield.Width = HSize * x;
            Minefield.Height = WSize * y;
            for (int i = 0; i < (x * y); i++)
            {
                ButtonList[i].Width = WSize;
                ButtonList[i].Height = HSize;
                ButtonList[i].FontSize = FSize;
            }

        }

        private void Game_Size_Switch(bool D_GSS)
        {
            if (D_GSS == false && GSS > 0)
                GSS--;
            else if (D_GSS == true && GSS < 2)
                GSS++;

            switch (GSS)
            {
                case 0: RB_100.IsChecked = true; break;
                case 1: RB_150.IsChecked = true; break;
                case 2: RB_200.IsChecked = true; break;
            }
        }

        private void Help()
        {
            try
            {
                string commandText = "Help.chm";
                var proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = commandText;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
            }
            catch
            {
                MessageBox.Show("Не найден файл справки!");
            }
        }

        #endregion

        #region Элементы формы

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            New_Game();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Help();
        }

        private void Smile_Click(object sender, RoutedEventArgs e)
        {
            New_Game();
        }

        private void Beginner_Click(object sender, RoutedEventArgs e)
        {
            Beginner_Mode();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
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
            }
        }

        private void RB_100_Checked(object sender, RoutedEventArgs e)
        {
            HSize = WSize = 20;
            FSize = 12;
            SBSize = 40;
            TBWSize = 60;
            TBFSize = 20;
            MineField_Elements_Size();
            Window_Size();
        }

        private void RB_150_Checked(object sender, RoutedEventArgs e)
        {
            HSize = WSize = 30;
            FSize = 15;
            SBSize = 60;
            TBWSize = 90;
            TBFSize = 30;
            MineField_Elements_Size();
            Window_Size();
        }

        private void RB_200_Checked(object sender, RoutedEventArgs e)
        {
            HSize = WSize = 40;
            FSize = 20;
            SBSize = 80;
            TBWSize = 120;
            TBFSize = 40;
            MineField_Elements_Size();
            Window_Size();
        }

        private void Enthusiast_Click(object sender, RoutedEventArgs e)
        {
            Enthusiast_Mode();
        }

        private void Records_Click(object sender, RoutedEventArgs e)
        {
            Transition_Records_Window();
        }

        private void Professional_Click(object sender, RoutedEventArgs e)
        {
            Professional_Mode();
        }

        private void Special_Click(object sender, RoutedEventArgs e)
        {
            Transition_Special_Window();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}