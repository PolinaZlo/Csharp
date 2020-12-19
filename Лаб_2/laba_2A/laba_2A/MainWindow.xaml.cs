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

namespace laba_2A
{
    class Shape
    {
        protected double S;
        protected double P;
        protected string Name;

        public Shape()
        {
            S = 0;
            P = 0;
            Name = "";
        }

        public void Show(Label lbl)
        {
            lbl.Content = "Фигура - > " + Name + "\nS = " + S + "\nP = " + P;
        }
    }

    class Rect : Shape
    {
        private double a, b;

        private double Square(double a, double b)
        {
            return a * b;
        }
        private double Perimeter(double a, double b)
        {
            return a * 2 + b * 2;
        }

        public Rect() : base()
        {
            Name = "Прямоугольник";
        }

        public Rect(double a, double b)
        {
            S = Square(a, b);
            P = Perimeter(a, b);
            Name = "Прямоугольник";
        }
    }
    class Square : Rect
    {
        private double a;

        public Square() : base()
        {
            Name = "Квадрат";
        }

        public Square(double a) : base(a, a)
        {
            Name = "Квадрат";
        }
    }
    class Circle : Shape
    {
        private double r;

        private double Square(double r)
        {
            return Math.PI * r * r;
        }
        private double Perimeter(double r)
        {
            return 2 * Math.PI * r;
        }

        public Circle() : base()
        {
            Name = "Круг";
        }

        public Circle(double r)
        {
            S = Square(r);
            P = Perimeter(r);
            Name = "Круг";
        }
    }

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void goBtn_Click(object sender, RoutedEventArgs e)
        {
            Shape shape = null;
            if (shapeBox.SelectedIndex == 0)
            {
                double a, b;
                a = Convert.ToDouble(TextBox1.Text);
                b = Convert.ToDouble(TextBox2.Text);
                shape = new Rect(a, b);
            }
            else if (shapeBox.SelectedIndex == 1)
            {
                double r;
                r = Convert.ToDouble(TextBox1.Text);
                shape = new Circle(r);
            }
            else if (shapeBox.SelectedIndex == 2)
            {
                double a;
                a = Convert.ToDouble(TextBox1.Text);
                shape = new Square(a);
            }
            shape.Show(showLabel);
        }

        private void itemChange(object sender, SelectionChangedEventArgs e)
        {
            TextBox1.Visibility = Visibility.Visible;
            if (shapeBox.SelectedIndex == 0)
            {
                aLbl.Content = "Сторона a";
                bLbl.Content = "Сторона b";
                bLbl.Visibility = Visibility.Visible;
                TextBox2.Visibility = Visibility.Visible;
            }
            else if (shapeBox.SelectedIndex == 1)
            {
                aLbl.Content = "Радиус окружности";
                bLbl.Visibility = Visibility.Hidden;
                TextBox2.Visibility = Visibility.Hidden;
            }
            else if (shapeBox.SelectedIndex == 2)
            {
                aLbl.Content = "Сторона квадрата";
                bLbl.Visibility = Visibility.Hidden;
                TextBox2.Visibility = Visibility.Hidden;
            }
        }
    }
}
