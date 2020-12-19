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
using System.IO;
using System.Windows.Forms;

namespace Laba_6C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtb.Document.Blocks.Clear();
                string path = dialog.FileName;

                StreamReader sr = new StreamReader(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                    rtb.AppendText(line + "\r\n");
                sr.Close();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                StreamWriter sw = new StreamWriter(path);
                string txt = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
                sw.Write(txt);
                sw.Close();
            }
        }

        private void WriteBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;

                StreamWriter sw = new StreamWriter(path, true);
                string txt = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd).Text;
                sw.Write(txt);
                sw.Close();
            }
        }
    }
}
