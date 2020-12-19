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

namespace Laba_6D
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Tag = drive;
                item.Header = drive.Name;
                item.Items.Add("kostil");
                tv.Items.Add(item);
            }
        }

        private void Tv_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;
            item.Items.Clear();
            DirectoryInfo dir = null;
            if (item.Tag is DriveInfo)
            {
                DriveInfo drive = (DriveInfo)item.Tag;
                dir = drive.RootDirectory;
            }
            else if (item.Tag is DirectoryInfo)
                dir = (DirectoryInfo)item.Tag;
            try
            {
                foreach (DirectoryInfo SubDir in dir.GetDirectories())
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Tag = SubDir;
                    newItem.Header = SubDir.Name;
                    newItem.Items.Add("kostil");
                    item.Items.Add(newItem);
                }
                foreach (FileInfo SubDir in dir.GetFiles())
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Tag = SubDir;
                    newItem.Header = SubDir.Name;
                    item.Items.Add(newItem);
                }
            }
            catch (Exception)
            { }
        }

        private void Tv_Selected(object sender, RoutedEventArgs e)
        {
            rtb.Document.Blocks.Clear();
            TreeViewItem item = (TreeViewItem)e.OriginalSource;
            FileSystemInfo dir = null;
            if (item.Tag is DriveInfo)
            {
                DriveInfo drive = (DriveInfo)item.Tag;
                dir = drive.RootDirectory;
            }
            else if (item.Tag is DirectoryInfo)
                dir = (DirectoryInfo)item.Tag;
            else dir = (FileInfo)item.Tag;
            rtb.AppendText("Attributes: " + String.Join(", ", dir.Attributes) + "\n" +
                "Creation Time: " + dir.CreationTime + "\n" +
                "Last Opened: " + dir.LastAccessTime + "\n" +
                "Last Edited: " + dir.LastWriteTime + "\n" +
                "Full Name: " + dir.FullName + "\n" +
                "Name: " + dir.Name);
        }
    }
}
