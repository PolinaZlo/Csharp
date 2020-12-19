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

namespace laba_1A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int sum,price,del=0;
        string type;
        coffeeMecha Americano = new coffeeMecha("Американо", 80);
        coffeeMecha Cappuccino = new coffeeMecha("Капучино", 70);
        coffeeMecha Espresso = new coffeeMecha("Эспрессо", 60);
        coffeeMecha Cocoa = new coffeeMecha("Какао", 50);
        coffeeMecha Suga = new coffeeMecha("Сахар", 10);
        coffeeMecha milk = new coffeeMecha("Молоко", 10);

        private void Rb1_Checked(object sender, RoutedEventArgs e)//работа с radiobutton
        {
            Ok.IsEnabled = true;
            ch1.IsEnabled = true;
            ch2.IsEnabled = true;
            Coffee.Visibility = Visibility.Visible;
            if (rb1.IsChecked==true)
                {
                
                Coffee.Source = new BitmapImage(new Uri(@"E:\Колледж\курс 4\СИРОП (ИСРПО)\Лаб_1\laba_1A\cof1.png"));//E:\Колледж\курс 4\СИРОП (ИСРПО)\Лаб_1\laba_1A\cof1.png
                price = Americano.Price();
                type = Americano.Type();
            }
            if (rb2.IsChecked == true)
            {
                
                Coffee.Source = new BitmapImage(new Uri(@"E:\Колледж\курс 4\СИРОП (ИСРПО)\Лаб_1\laba_1A\cof2.png"));
                price = Cappuccino.Price();
                type = Cappuccino.Type();
            }
            if (rb3.IsChecked == true)
            {
                
                Coffee.Source = new BitmapImage(new Uri(@"E:\Колледж\курс 4\СИРОП (ИСРПО)\Лаб_1\laba_1A\cof3.png"));
                price = Espresso.Price();
                type = Espresso.Type();
            }
            if (rb4.IsChecked == true)
            {
                
                Coffee.Source = new BitmapImage(new Uri(@"E:\Колледж\курс 4\СИРОП (ИСРПО)\Лаб_1\laba_1A\cof4.png"));
                price = Cocoa.Price();
                type = Cocoa.Type();
            }
            if(ch1.IsChecked==true)
            {
                Sugar.Visibility = Visibility.Visible;
                Sugar.Source = new BitmapImage(new Uri(@"E:\Колледж\курс 4\СИРОП (ИСРПО)\Лаб_1\laba_1A\sug.png"));
                price += Suga.Price();
            }
            if (ch2.IsChecked == true)
            {
                Milk.Visibility = Visibility.Visible;
                Milk.Source = new BitmapImage(new Uri(@"E:\Колледж\курс 4\СИРОП (ИСРПО)\Лаб_1\laba_1A\milk.png"));
                price += Suga.Price();
            }
 
            price_lab.Content = "Цена напитка: " + price;
        }


        private void ch1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (del == 0)
            {
                if (ch1.IsChecked == false)
                {
                    Sugar.Visibility = Visibility.Hidden;
                    price -= Suga.Price();
                }
                if (ch2.IsChecked == false)
                {
                    Milk.Visibility = Visibility.Hidden;
                    price -= milk.Price();
                }
                price_lab.Content = "Цена напитка: " + price;
            }
        }

        private void Button_IN(object sender, RoutedEventArgs e)
        {
            try
            {
                sum += int.Parse(tb_input.Text);
                if (sum > 0 )
                {
                    money_in.Content = "Внесеннная сумма: " + sum;
                }
                else
                {
                    money_in.Content = "Внесеннная сумма: " + sum;
                }
            }
            catch
            {}
            tb_input.Clear();
        }

        private void Tb_input_GotFocus(object sender, RoutedEventArgs e)
        {
            tb_input.Clear();
            del_money.Content = "Сдача: ";
            del = 0;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (price > sum || sum == 0)
                MessageBox.Show("Недостаточно средств! Внесите нужную сумму!");
            else
            {
                MessageBox.Show(type + " готов");
                Ok.IsEnabled = false;
                Coffee.Visibility = Visibility.Hidden;
                Milk.Visibility = Visibility.Hidden;
                Sugar.Visibility = Visibility.Hidden;
                del = sum - price;
                rb1.IsChecked = false;
                rb2.IsChecked = false;
                rb3.IsChecked = false;
                rb4.IsChecked = false;
                ch1.IsChecked = false;
                ch2.IsChecked = false;
                ch1.IsEnabled = false;
                ch2.IsEnabled = false;
                sum = 0;
                price = 0;
                price_lab.Content = "Цена напитка: ";
                money_in.Content = "Внесеннная сумма: ";
                del_money.Content = "Сдача: " + del;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Ok.IsEnabled = false;
            ch1.IsEnabled = false;
            ch2.IsEnabled = false;
        }
        class coffeeMecha
        {
            private int price;
            private string type;

            public coffeeMecha(string type, int price)
            {
                this.type = type;
                this.price = price;
            }
            public int Price()
            {return this.price;}
            public string Type()
            {return this.type; }
        }

        
    }
}
