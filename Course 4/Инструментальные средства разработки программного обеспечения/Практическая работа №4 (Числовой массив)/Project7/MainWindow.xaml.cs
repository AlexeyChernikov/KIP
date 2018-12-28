using System;
using System.Windows;
using System.Data;

namespace Project7
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


        private void DataGrid_Initialized(object sender, EventArgs e)
        {
            MainDataGrid.ItemsSource = DataGridInput(true).DefaultView;
        }

        //Основная

        private void MainDiagonalSum_Initialized(object sender, EventArgs e)
        {
            MainDiagonalSum.Content = "Сумма элементов: " + MainDiagonalSum1().ToString();
        }

        private void MainDiagonaMin_Initialized(object sender, EventArgs e)
        {
            MainDiagonaMin.Content = "Минимальный элемент: " + MainDiagonalMin1().ToString();
        }

        private void MainDiagonalMax_Initialized(object sender, EventArgs e)
        {
            MainDiagonalMax.Content = " Максимальный элемент: " + MainDiagonalMax1().ToString();
        }

        //Побочная

        private void SecondaryDiagonalSum_Initialized(object sender, EventArgs e)
        {
            SecondaryDiagonalSum.Content = "Сумма элементов: " + SecondaryDiagonalSum1().ToString();
        }

        private void SecondaryDiagonaMin_Initialized(object sender, EventArgs e)
        {
            SecondaryDiagonaMin.Content = "Минимальный элемент: " + SecondaryDiagonalMin1().ToString();
        }

        private void SecondaryDiagonalMax_Initialized(object sender, EventArgs e)
        {
            SecondaryDiagonalMax.Content = " Максимальный элемент: " + SecondaryDiagonalMax1().ToString();
        }

        //Левый

        private void LeftTriangleSum_Initialized(object sender, EventArgs e)
        {
            LeftTriangleSum.Content = "Сумма элементов: " + LeftTriangleSum1().ToString();
        }

        private void LeftTriangleMin_Initialized(object sender, EventArgs e)
        {
            LeftTriangleMin.Content = "Минимальный элемент: " + LeftTriangleMin1().ToString();
        }

        private void LeftTriangleMax_Initialized(object sender, EventArgs e)
        {
            LeftTriangleMax.Content = " Максимальный элемент: " + LeftTriangleMax1().ToString();
        }

        //Правый

        private void RightTriangleSum_Initialized(object sender, EventArgs e)
        {
            RightTriangleSum.Content = "Сумма элементов: " + RightTriangleSum1().ToString();
        }

        private void RightTriangleMin_Initialized(object sender, EventArgs e)
        {
            RightTriangleMin.Content = "Минимальный элемент: " + RightTriangleMin1().ToString();
        }

        private void RightTriangleMax_Initialized(object sender, EventArgs e)
        {
            RightTriangleMax.Content = " Максимальный элемент: " + RightTriangleMax1().ToString();
        }

        //Верхний

        private void UpTriangleSum_Initialized(object sender, EventArgs e)
        {
            UpTriangleSum.Content = "Сумма элементов: " + UpTriangleSum1().ToString();
        }

        private void UpTriangleMin_Initialized(object sender, EventArgs e)
        {
            UpTriangleMin.Content = "Минимальный элемент: " + UpTriangleMin1().ToString();
        }

        private void UpTriangleMax_Initialized(object sender, EventArgs e)
        {
            UpTriangleMax.Content = " Максимальный элемент: " + UpTriangleMax1().ToString();
        }

        //Нижний

        private void DownTriangleSum_Initialized(object sender, EventArgs e)
        {
            DownTriangleSum.Content = "Сумма элементов: " + DownTriangleSum1().ToString();
        }

        private void DownTriangleMin_Initialized(object sender, EventArgs e)
        {
            DownTriangleMin.Content = "Минимальный элемент: " + DownTriangleMin1().ToString();
        }

        private void DownTriangleMax_Initialized(object sender, EventArgs e)
        {
            DownTriangleMax.Content = " Максимальный элемент: " + DownTriangleMax1().ToString();
        }

        private void Button_Initialized(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainDataGrid.ItemsSource=null;
            MainDataGrid.ItemsSource = DataGridInput(true).DefaultView;
            MainDiagonalSum.Content = "Сумма элементов: " + MainDiagonalSum1().ToString();
            MainDiagonaMin.Content = "Минимальный элемент: " + MainDiagonalMin1().ToString();
            MainDiagonalMax.Content = " Максимальный элемент: " + MainDiagonalMax1().ToString();
            SecondaryDiagonalSum.Content = "Сумма элементов: " + SecondaryDiagonalSum1().ToString();
            SecondaryDiagonaMin.Content = "Минимальный элемент: " + SecondaryDiagonalMin1().ToString();
            SecondaryDiagonalMax.Content = " Максимальный элемент: " + SecondaryDiagonalMax1().ToString();
            LeftTriangleSum.Content = "Сумма элементов: " + LeftTriangleSum1().ToString();
            LeftTriangleMin.Content = "Минимальный элемент: " + LeftTriangleMin1().ToString();
            LeftTriangleMax.Content = " Максимальный элемент: " + LeftTriangleMax1().ToString();
            RightTriangleSum.Content = "Сумма элементов: " + RightTriangleSum1().ToString();
            RightTriangleMin.Content = "Минимальный элемент: " + RightTriangleMin1().ToString();
            RightTriangleMax.Content = " Максимальный элемент: " + RightTriangleMax1().ToString();
            UpTriangleSum.Content = "Сумма элементов: " + UpTriangleSum1().ToString();
            UpTriangleMin.Content = "Минимальный элемент: " + UpTriangleMin1().ToString();
            UpTriangleMax.Content = " Максимальный элемент: " + UpTriangleMax1().ToString();
            DownTriangleSum.Content = "Сумма элементов: " + DownTriangleSum1().ToString();
            DownTriangleMin.Content = "Минимальный элемент: " + DownTriangleMin1().ToString();
            DownTriangleMax.Content = " Максимальный элемент: " + DownTriangleMax1().ToString();
        }

        static int[,] MainArray;
        private static Random random = new Random();

        public static int[,] GetArray()
        {
            int[,] array = new int[10, 10];
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)

                    array[i, j] = random.Next(0, 100);
            return array;
        }


        public static DataTable DataGridInput(bool flag)
        {
            MainArray = flag ? GetArray() : MainArray;

            var rows = MainArray.GetLength(0);
            var columns = MainArray.GetLength(1);

            var t = new DataTable();
            for (var c = 1; c <= columns; c++)
                t.Columns.Add(new DataColumn(c.ToString()));

            for (var r = 0; r < rows; r++)
            {
                var newRow = t.NewRow();
                for (var c = 0; c < columns; c++)
                    newRow[c] = MainArray[r, c];
                t.Rows.Add(newRow);
            }

            return t;
        }


        public static int MainDiagonalSum1()
        {

            int sum = 0;
            for (int i = 0; i < MainArray.GetLength(0); i++)
                for (int j = 0; j < MainArray.GetLength(1); j++)
                    if (i == j)
                        sum += MainArray[i, j];
            return sum;
        }

        public static int MainDiagonalMin1()
        {

            int min = MainArray[0, 0];
            for (int i = 0; i < MainArray.GetLength(0); i++)
                for (int j = 0; j < MainArray.GetLength(1); j++)
                    if ((i == j) && (MainArray[i, j] < min))
                        min = MainArray[i, j];

            return min;
        }


        public static int MainDiagonalMax1()
        {

            int max = MainArray[0, 0];
            for (int i = 0; i < MainArray.GetLength(0); i++)
                for (int j = 0; j < MainArray.GetLength(1); j++)
                    if ((i == j) && (MainArray[i, j] > max))
                        max = MainArray[i, j];

            return max;
        }

        public static int SecondaryDiagonalSum1()
        {

            int sum = 0;
            for (int i = 0; i < MainArray.GetLength(0); i++)
                for (int j = 0; j < MainArray.GetLength(1); j++)
                    if (i + j == 10 - 1)
                        sum += MainArray[i, j];
            return sum;
        }

        public static int SecondaryDiagonalMin1()
        {

            int min = MainArray[9, 0];
            for (int i = 0; i < MainArray.GetLength(0); i++)
                for (int j = 0; j < MainArray.GetLength(1); j++)
                    if ((i + j) == (10 - 1) && (MainArray[i, j] < min))
                        min = MainArray[i, j];

            return min;
        }

        public static int SecondaryDiagonalMax1()
        {

            int max = MainArray[9, 0];
            for (int i = 0; i < MainArray.GetLength(0); i++)
                for (int j = 0; j < MainArray.GetLength(1); j++)
                    if ((i + j) == (10 - 1) && (MainArray[i, j] > max))
                        max = MainArray[i, j];

            return max;
        }

        public static int LeftTriangleSum1()
        {
            int sum = 0;
            for (int i = 1; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j <= i && j <= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        sum += MainArray[i, j];
                    }
                }
            }
            return sum;
        }

        public static int LeftTriangleMin1()
        {
            int min = MainArray[1, 9];

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (min > MainArray[i, j] && j <= i && j <= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        min = MainArray[i, j];
                    }
                }
            }
            return min;
        }

        public static int LeftTriangleMax1()
        {
            int max = MainArray[1, 9];

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (max < MainArray[i, j] && j <= i && j <= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        max = MainArray[i, j];
                    }
                }
            }
            return max;
        }

        public static int RightTriangleSum1()
        {
            int sum = 0;
            for (int i = 1; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (j >= i && j >= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        sum += MainArray[i, j];
                    }
                }
            }
            return sum;
        }

        public static int RightTriangleMin1()
        {
            int min = MainArray[1, 0];

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (min > MainArray[i, j] && j >= i && j >= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        min = MainArray[i, j];
                    }
                }
            }
            return min;
        }

        public static int RightTriangleMax1()
        {
            int max = MainArray[1, 0];

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (max < MainArray[i, j] && j >= i && j >= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        max = MainArray[i, j];
                    }
                }
            }
            return max;
        }

        public static int UpTriangleSum1()
        {
            int sum = 0;
            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (j >= i && j <= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        sum += MainArray[i, j];
                    }
                }
            }
            return sum;
        }

        public static int UpTriangleMin1()
        {
            int min = MainArray[0, 1];

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (min > MainArray[i, j] && j >= i && j <= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        min = MainArray[i, j];
                    }
                }
            }
            return min;
        }

        public static int UpTriangleMax1()
        {
            int max = MainArray[0, 1];

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (max < MainArray[i, j] && j >= i && j <= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        max = MainArray[i, j];
                    }
                }
            }
            return max;
        }

        public static int DownTriangleSum1()
        {
            int sum = 0;

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (j <= i && j >= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        sum += MainArray[i, j];
                    }
                }
            }
            return sum;
        }

        public static int DownTriangleMin1()
        {
            int min = MainArray[9, 1];

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (min > MainArray[i, j] && j <= i && j >= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        min = MainArray[i, j];
                    }
                }
            }
            return min;
        }

        public static int DownTriangleMax1()
        {
            int max = MainArray[9, 1];

            for (int i = 0; i < MainArray.GetLength(0); i++)
            {
                for (int j = 0; j < MainArray.GetLength(1); j++)
                {
                    if (max < MainArray[i, j] && j <= i && j >= 10 - i - 1 && i != j && (i + j) != (10 - 1))
                    {
                        max = MainArray[i, j];
                    }
                }
            }
            return max;
        }
    }
}
