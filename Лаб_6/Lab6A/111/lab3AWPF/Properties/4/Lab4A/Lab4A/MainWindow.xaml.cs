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

namespace Lab4A
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

        private void BoldBtn_Click(object sender, RoutedEventArgs e)
        {
            rtb.FontWeight = rtb.FontWeight == FontWeights.Bold ? FontWeights.Normal : FontWeights.Bold;
        }

        private void ItalicBtn_Click(object sender, RoutedEventArgs e)
        {
            rtb.FontStyle = rtb.FontStyle == FontStyles.Italic ? FontStyles.Normal : FontStyles.Italic;
        }

        private void FontCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (fontCB.SelectedIndex == 0)
                rtb.FontFamily = new FontFamily("Times New Roman");
            if (fontCB.SelectedIndex == 1)
                rtb.FontFamily = new FontFamily("Comic Sans MS");
            if (fontCB.SelectedIndex == 2)
                rtb.FontFamily = new FontFamily("Century");
           
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rtb.FontSize = sizeSlider.Value;
        }
    }
}
