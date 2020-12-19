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

namespace laba_2B
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int a;
            int? b = null;
            a = b??-1;
            InitializeComponent();
        }
        private Image NewImage(string path)
        {
            var uriImageSource = new Uri(@path, UriKind.RelativeOrAbsolute);
            Image image = new Image();
            image.Width = 80;
            image.Source = new BitmapImage(uriImageSource);
            return image;
        }

        Deck deck;

        private void ShowDeck()
        {
            stackPanel.Children.Clear();
            StackPanel[] sp = new StackPanel[13];
            string path;
            byte k = 0;
            for (byte i = 0; i < 13; i++)
            {
                sp[i] = new StackPanel();
                sp[i].Orientation = Orientation.Horizontal;
                for (byte j = 0; j < 4; j++)
                {
                    path = "Res/";
                    path += deck.GetCard(k) + ".png";
                    sp[i].Children.Add(NewImage(path));
                    k++;
                }
                stackPanel.Children.Add(sp[i]);
            }
        }

        private void Cards_Click(object sender, RoutedEventArgs e)
        {
            deck = new Deck();
            ShowDeck();
        }

        private void Shuffle_Click(object sender, RoutedEventArgs e)
        {
            if (deck != null)
            {
                deck.Shuffle();
                ShowDeck();
            }
        }
    }
}
