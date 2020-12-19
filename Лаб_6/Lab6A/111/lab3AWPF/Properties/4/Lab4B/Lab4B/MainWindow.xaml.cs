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

namespace Lab4B
{
    class A
    {
        public virtual int F() { return 0; }
    }
    class B : A
    {
        public int F() { return 1; }
    }
    class C : B
    {
        public int F() { return 2; }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            A a = new C();
            int i = a.F();
            i = ((C)a).F();
            MessageBox.Show(i.ToString());

            InitializeComponent();
            foreach (var key in System.Windows.Media.Fonts.SystemFontFamilies)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = key.ToString();
                item.FontFamily = key;
                fontLB.Items.Add(item);
            }
        }

        private void BoldBtn_Click(object sender, RoutedEventArgs e)
        {
            rtb.FontWeight = rtb.FontWeight == FontWeights.Bold ? FontWeights.Normal : FontWeights.Bold;
        }

        private void ItalicBtn_Click(object sender, RoutedEventArgs e)
        {
            rtb.FontStyle = rtb.FontStyle == FontStyles.Italic ? FontStyles.Normal : FontStyles.Italic;
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rtb.FontSize = sizeSlider.Value;
        }

        private void FontLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rtb.FontFamily = new FontFamily(((ListBoxItem)fontLB.SelectedItem).Content.ToString());
        }
    }
}