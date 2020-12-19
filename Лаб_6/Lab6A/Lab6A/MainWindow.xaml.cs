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
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Lab6A
{
    public static class StringExeption
    {
        public static int CountOf(this string str, char c)
        {
            int Counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    Counter++;
            }
            return Counter;
        }

    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path = null;
        private string selectedPath = null;

        public MainWindow()
        {
            InitializeComponent();
            //метод расширения для пункта А
        //для B создать таблицу и из ПРОГРАММЫ ввести туда данные типа база люди таблица человек имя фамилия
            string str = "Hello world!!!";
            int c = str.CountOf('l');
            Console.Write("{0}", c);

        }
        


        private void DialogBtn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                searchBtn.IsEnabled = true;
                path = folderBrowserDialog.SelectedPath;
                pathTB.Text = path;
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();

            string filter = filterTB.Text;
            if (filter == "")
            {
                filter = "*.*";
            }
            if (rdBtn.IsChecked == true)
            {
                foreach (var el in GetAllFiles(path, filter))
                    listBox.Items.Add(el);
            }
            else
            {
                string[] files = Directory.GetFiles(path, filter);
                foreach (var el in files)
                    listBox.Items.Add(el);
            }
        }

        IEnumerable<String> GetAllFiles(string path, string searchPattern)
        {
            return System.IO.Directory.EnumerateFiles(path, searchPattern).Union(
                System.IO.Directory.EnumerateDirectories(path).SelectMany(d =>
                {
                    try
                    {
                        return GetAllFiles(d, searchPattern);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        return Enumerable.Empty<String>();
                    }
                }));
        }
        private void ListBox_ItemClick(object sender, MouseButtonEventArgs e)
        {
            zipBtn.IsEnabled = true;
            txtRTB.Document.Blocks.Clear();
            int index = listBox.SelectedIndex;
            selectedPath = listBox.Items.GetItemAt(index).ToString();
            string line = "";
            StreamReader sr = new StreamReader(selectedPath, Encoding.UTF8, true);
            while ((line = sr.ReadLine()) != null)
                txtRTB.Document.Blocks.Add(new Paragraph(new Run(line)));

        }

        private void ZipBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ZipArchive zip = ZipFile.Open(selectedPath.Split('.')[0] + ".zip", ZipArchiveMode.Create);
                zip.CreateEntryFromFile(selectedPath, selectedPath.Substring(selectedPath.LastIndexOf('\\') + 1));
                System.Windows.MessageBox.Show("Файл добавлен в архив");
                zip.Dispose();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Ошибка - " + ex.Message);
            }
        }
    }
}