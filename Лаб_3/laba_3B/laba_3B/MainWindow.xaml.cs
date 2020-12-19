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

namespace laba_3B
{
    public partial class MainWindow : Window
    {
        private int Angle = 0;
        private double x = 1;
        private double y = 1;
        private double xpos = 0;
        private double ypos = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Decrease_Click(object sender, RoutedEventArgs e)
        {

            x -= 0.1;
            y -= 0.1;
            Transform();
        }

        private void Increase_Click(object sender, RoutedEventArgs e)
        {
            x += 0.1;
            y += 0.1;
            Transform();
        }

        private void RotateLeft_Click(object sender, RoutedEventArgs e)
        {
            Angle -= 30;
            Transform();
        }

        private void RotateRight_Click(object sender, RoutedEventArgs e)
        {
            Angle += 30;
            Transform();
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            ypos -= 15;
            Transform();
        }

        private void MoveLeft_Click(object sender, RoutedEventArgs e)
        {
            xpos -= 15;
            Transform();
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            ypos += 15;
            Transform();
        }

        private void Move_Right_Click(object sender, RoutedEventArgs e)
        {
            xpos += 15;
            Transform();
        }


        private void Transform()
        {
            TranslateTransform translateTransform = new TranslateTransform(xpos, ypos);
            ScaleTransform scaleTransform = new ScaleTransform(x, y, 150, 150);
            RotateTransform rotateTransform = new RotateTransform(Angle, 150, 150);

            TransformGroup transformGroup = new TransformGroup();

            transformGroup.Children.Add(translateTransform);
            transformGroup.Children.Add(scaleTransform);
            transformGroup.Children.Add(rotateTransform);

            img.RenderTransform = transformGroup;
        }
    }
}
