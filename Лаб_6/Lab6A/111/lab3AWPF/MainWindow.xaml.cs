using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace lab3AWPF
{
    class Person: INotifyPropertyChanged
    {
        private string name;
        public string Name { get { return name; } set {name = value; OnPropertyChanged("Name"); } }
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Person p1;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)this.Resources["p1"];
            p.Name = "Jessika";
        }
        


    }
}
