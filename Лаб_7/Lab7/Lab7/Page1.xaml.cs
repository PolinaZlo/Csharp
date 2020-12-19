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

namespace Lab7
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private Page2 p;
        public Page1()
        {
            InitializeComponent();
            p = new Page2(this);
        }

        public void updateList(ListBoxItem[] items)
        {
            for (int i = 0; i < items.Length; i++)
                this.lb.Items.Add(items[i]);
        }

        private void SelectBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lb.Items.Count == 0)
                this.NavigationService.Navigate(p);
            else
            {
                ListBoxItem[] listBoxItems = new ListBoxItem[lb.Items.Count];
                for (int i = listBoxItems.Length - 1; i >= 0; i--)
                {
                    listBoxItems[i] = (ListBoxItem)lb.Items.GetItemAt(i);
                    lb.Items.Remove(listBoxItems[i]);
                }
                p.kostil(listBoxItems);
                this.NavigationService.Navigate(p);
            }
        }

        private void BuyBtn_Click(object sender, RoutedEventArgs e)
        {
            int delivery = 0;
            int price = 0;
            if ((bool)r1.IsChecked)
                price += 600;
            else if ((bool)r2.IsChecked)
                price += 450;
            else if ((bool)r3.IsChecked)
                price += 290;
            price += 25 * lb.Items.Count;
            if (price < 500)
                delivery = 200;
            MessageBox.Show("Цена пиццы = " + price + " руб.\nЦена доставки" + (delivery == 0 ? " - бесплатно!" : (" = " + delivery + " руб.")));
        }
    }
}
