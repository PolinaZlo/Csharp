using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace laba_3A
{
    public partial class MainWindow : Window
    {
        class Table
        {
            public string Key_Code { get; set; }
            public int Key_Value { get; set; }
            public string Key_State { get; set; }
            public char Key_Char { get; set; }
            public string System_Key { get; set; }
            public string Key_Down { get; set; }
            public string Key_Up { get; set; }

            public Table(KeyEventArgs k)
            {
                Key_Code = k.Key.ToString();
                Key_Value = (int)k.Key;
                Key_State = k.KeyStates.ToString();
                Key_Char = (char)k.Key;
                System_Key = k.SystemKey.ToString();
                Key_Down = k.IsDown.ToString();
                Key_Up = k.IsUp.ToString();
            }
        }
        ObservableCollection<Table> List = new ObservableCollection<Table>();
        public MainWindow()
        {
            Action<string, int, double> fg = (x, y, z) => { Console.Write("a"); };
            InitializeComponent();
            grid.ItemsSource = List;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            List.Add(new Table(e));
        }
    }
}
