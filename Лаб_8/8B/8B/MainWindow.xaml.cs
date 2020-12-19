using System;
using System.Collections.Generic;
using System.IO;
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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace _8B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Gallery> gallery = new ObservableCollection<Gallery> { };
        int rotation = 0;
        RotateTransform rotateTransform = new RotateTransform();
        public MainWindow()
        {
            InitializeComponent();
            gallery.CollectionChanged += GalleryChanged;
            showMustGoOn.RenderTransformOrigin = new Point(0.5, 0.5);
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog OpenFileD = new System.Windows.Forms.OpenFileDialog();
            OpenFileD.Filter = "Images (*.bmp, *.gif, *.jpeg, *.jpg, *.png, *.tif)|*.bmp; *.gif; *.jpeg; *.jpg; *.png; *.tif";
            if (OpenFileD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                gallery.Add(new Gallery() { path = OpenFileD.FileName });
        }
        private void GalleryChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IList<System.Windows.Controls.Image> images = new List<System.Windows.Controls.Image>();
            Gallery picture = e.NewItems[0] as Gallery;
            listOfImages.Items.Add(picture.path.Substring(picture.path.LastIndexOf('\\') + 1));
            foreach (var galleryImg in gallery)
            {
                try
                {
                    var bi = new BitmapImage(new Uri(galleryImg.path));
                    var img = new System.Windows.Controls.Image() { Width = 200, Height = 200, Margin = new Thickness(5) };
                    img.Source = bi;
                    images.Add(img);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            try { imaginedList.Items.Clear(); }
            catch { }
            imaginedList.ItemsSource = images;
        }

        private void ShowImage(object sender, MouseButtonEventArgs e)
        {
            Turns(-rotation);
            showMustGoOn.Source = new BitmapImage(new Uri(gallery[(sender as ListBox).SelectedIndex].path));
        }
        private void LeftTurn(object sender, RoutedEventArgs e)
        {
            Turns(-90);
        }

        private void RightTurn(object sender, RoutedEventArgs e)
        {
            Turns(90);
        }
        private void Turns(int rotationAngle)
        {
            rotation += rotationAngle;
            rotateTransform = new RotateTransform(rotation);
            showMustGoOn.RenderTransform = rotateTransform;
        }
    }
}
