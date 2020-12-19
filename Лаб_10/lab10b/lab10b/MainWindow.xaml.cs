using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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

namespace lab10b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet myDataSet;
        SqlDataAdapter adapter;
        SqlConnection conn;
        public MainWindow()
        {
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\zpoli\\OneDrive\\Рабочий стол\\ИСРПО\\lab10\\lab10b\\lab10b\\db.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(connString);
            adapter = new SqlDataAdapter("SELECT * FROM Basic", conn);

            myDataSet = new DataSet();
            adapter.Fill(myDataSet, "BasicDB");
            InitializeComponent();
            lb.DataContext = myDataSet;
            
        }

        private void RefreshDB()
        {
            myDataSet.Clear();
            adapter.Fill(myDataSet, "BasicDB");
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshDB();
        }
    }
}
