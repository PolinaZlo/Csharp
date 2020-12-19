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

namespace laba_3C
{
    class A : ICloneable
    {
        public int a;
        public int b;
        public string c;
        
        public object Clone()
        {
            //если класс - то вручную
            //A B = new A();
            //return B;
            return this.MemberwiseClone();//работает на простые значения
        }

    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            A a = new A(), b;
            a.a = 2;
            a.b = 3;
            a.c = "g";
            b = (A)a.Clone();
            InitializeComponent();

        }
        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            polygon.Points.Add(e.GetPosition(this));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            polygon.Points.Clear();
        }
    }
}
