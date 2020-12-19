﻿using System;
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

namespace Laba_5A
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
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                r1.IsChecked = true;
                MessageBox.Show("Событие поднялось в TextBox");
            }
            if (sender is Grid)
            {
                r2.IsChecked = true;
                MessageBox.Show("Событие поднялось в Grid");
            }
            if (sender is Window)
            {
                r3.IsChecked = true;
                MessageBox.Show("Событие поднялось в Window");
                r3.IsChecked = false;
            }

        }
    }
}
