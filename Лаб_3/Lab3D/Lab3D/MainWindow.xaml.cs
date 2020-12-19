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

namespace Lab3D
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush brush;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VisualButton_Click(object sender, RoutedEventArgs e)
        {
            brush = new VisualBrush();
            (brush as VisualBrush).Visual = Trolling;
            Paint();
        }

        private void ImgBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new ImageBrush();
            (brush as ImageBrush).ImageSource = new BitmapImage(new Uri("Resources/photo2.jpg", UriKind.Relative));
            Paint();
        }

        private void GrBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new LinearGradientBrush();
            GradientStop gs = new GradientStop();
            GradientStop gs1 = new GradientStop();
            GradientStop gs2 = new GradientStop();
            gs.Color = Color.FromRgb(255, 0, 0);
            gs.Offset = 0;
            gs1.Color = Color.FromRgb(0, 255, 0);
            gs1.Offset = 0.5;
            gs2.Color = Color.FromRgb(0, 0, 255);
            gs2.Offset = 1;
            (brush as LinearGradientBrush).GradientStops.Add(gs);
            (brush as LinearGradientBrush).GradientStops.Add(gs1);
            (brush as LinearGradientBrush).GradientStops.Add(gs2);
            Paint();
        }

        private void radBtn_Click(object sender, RoutedEventArgs e)
        {
            brush = new RadialGradientBrush();
            GradientStop gs = new GradientStop();
            GradientStop gs1 = new GradientStop();
            GradientStop gs2 = new GradientStop();
            gs.Color = Color.FromRgb(255, 0, 0);
            gs.Offset = 0;
            gs1.Color = Color.FromRgb(0, 255, 0);
            gs1.Offset = 0.5;
            gs2.Color = Color.FromRgb(0, 0, 255);
            gs2.Offset = 1;
            (brush as RadialGradientBrush).GradientStops.Add(gs);
            (brush as RadialGradientBrush).GradientStops.Add(gs1);
            (brush as RadialGradientBrush).GradientStops.Add(gs2);
            Paint();

        }
        
        private void Paint()
        {
            el.Fill = brush;
        }
    }
}
