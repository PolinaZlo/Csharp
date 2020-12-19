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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private Page1 p;
        public Page2(Page1 p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lb1.SelectedIndex == -1)
                MessageBox.Show("Выберите начинку!");
            else
            {
                ListBoxItem listBoxItem = (ListBoxItem)lb1.Items.GetItemAt(lb1.SelectedIndex);
                lb1.Items.Remove(listBoxItem);
                lb2.Items.Add(listBoxItem);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (lb2.SelectedIndex == -1)
                MessageBox.Show("Выберите начинку!");
            else
            {
                ListBoxItem listBoxItem = (ListBoxItem)lb2.Items.GetItemAt(lb2.SelectedIndex);
                lb2.Items.Remove(listBoxItem);
                lb1.Items.Add(listBoxItem);
            }
        }

        public void kostil(ListBoxItem[] items)
        {
            for (int i = 0; i < items.Length; i++)
                this.lb2.Items.Add(items[i]);
        }

        private void FinishBtn_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem[] listBoxItems = new ListBoxItem[lb2.Items.Count];
            for (int i = listBoxItems.Length - 1; i >= 0; i--)
            {
                listBoxItems[i] = (ListBoxItem)lb2.Items.GetItemAt(i);
                lb2.Items.Remove(listBoxItems[i]);
            }
            p.updateList(listBoxItems);
            this.NavigationService.Navigate(p);
        }
    }
}
