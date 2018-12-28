﻿using System;
using System.Collections.Generic;
using System.Dynamic;
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

namespace Project2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InputTextbox.Focus();
        }


        static public String Checker(double x, double a)
        {
            double y = 0;
            double u = 0;
            if (x < 0)
            {
                y = x * x * Math.Sin(x + a);
            }
            else if (x >= 0)
            {
                u = Math.Log(x + a);
                if (u == 0)
                    return "Деление на ноль";

                 y = x / u;
                if (Double.IsNaN(y))
                {
                    return "Нет решения функциии";
                }
               

            }
            return System.Convert.ToString(y);
        }

        private void InputTextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                try
                {
                    MainDataGrid.Columns.RemoveAt(1);
                    MainDataGrid.Columns.RemoveAt(0);
                    MainDataGrid.Items.Clear();
                }
                catch (Exception)
                {

                }

                double a = System.Convert.ToDouble(InputTextbox.Text);
                string[] labels = new string[] { "Значение X", "Значение Y" };

                foreach (string label in labels)
                {
                    DataGridTextColumn column = new DataGridTextColumn();
                    column.Header = label;
                    column.Binding = new Binding(label.Replace(' ', '_'));

                    MainDataGrid.Columns.Add(column);
                }

                for (int i = -20; i < 21; i++)
                    if ((i >= -20) && (i <= 20))
                    {

                        string[] values = new string[] { System.Convert.ToString(i), Convert.ToString(Checker(i, a)) };

                        dynamic row = new ExpandoObject();

                        for (int ii = 0; ii < labels.Length; ii++)
                            ((IDictionary<String, Object>)row)[labels[ii].Replace(' ', '_')] = values[ii];

                        MainDataGrid.Items.Add(row);
                    }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введено некорректное значение");
                InputTextbox.Focus();
            }
        }
    }
}
