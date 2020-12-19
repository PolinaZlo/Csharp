using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using DataTable = System.Data.DataTable;
using Table = Microsoft.Office.Interop.Word.Table;
using Word = Microsoft.Office.Interop.Word;

namespace L11A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        string templateFile = @"C:\Users\zpoli\OneDrive\Рабочий стол\ИСРПО\lab12\12A\Template.docx";
        List<Items> list = new List<Items>
        {
            new Items {Name = "Тест1", Id = 1, Price = 1},
            new Items {Name = "Тест2", Id = 2, Price = 2},
            new Items {Name = "Тест3", Id = 3, Price = 3},
            new Items {Name = "Тест4", Id = 4, Price = 4},
            new Items {Name = "Тест5", Id = 5, Price = 5},
            new Items {Name = "Тест6", Id = 6, Price = 6},
        };

        public MainWindow()
        {
            InitializeComponent();
            dgData.ItemsSource = list;
        }

        private DataTable ToDataTable(List<Items> list)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Items));
            DataTable dt = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (Items item in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyDescriptor pdt in properties)
                {
                    row[pdt.Name] = pdt.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public void CreateTable(DataTable dt, Word.Document oDoc)
        {
            int RowCount = dt.Rows.Count; int ColumnCount = dt.Columns.Count;
            Object[,] DataArray = new object[RowCount, ColumnCount];

            for (int c = 0; c < ColumnCount; c++)
            {
                int r = 0;
                DataArray[r, c] = dt.Columns[c].ColumnName;
                for (r = 0; r < RowCount; r++)
                {
                    DataArray[r, c] = dt.Rows[r][c];
                }
            }

            Table table = oDoc.Tables[1];
            object oMissing = System.Reflection.Missing.Value;
            for (int r = 0; r < RowCount; r++)
            {
                Row row = table.Rows.Add(ref oMissing);
                for (int c = 0; c < ColumnCount; c++)
                {
                    row.Cells[c+1].Range.Text = DataArray[r, c].ToString();
                    row.Cells[c+1].WordWrap = true;
                }
            }

            for (int c = 0; c < ColumnCount; c++)
            {
                table.Cell(1, c + 1).Range.Text = dt.Columns[c].ColumnName;
            }

        }

        private void WriteBtn_Click(object sender, RoutedEventArgs e)
        {
            var supplier = supplierTxb.Text;
            var buyer = buyerTxb.Text;

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                var wordDoc = wordApp.Documents.Open(templateFile);
                ReplaceWord("{supplier}", supplier, wordDoc);
                ReplaceWord("{buyer}", buyer, wordDoc);

                CreateTable(ToDataTable(list), wordDoc);

                wordDoc.SaveAs2(@"C:\Users\zpoli\OneDrive\Рабочий стол\ИСРПО\lab12\12A\result.docx");
                wordApp.Visible = true; 
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void ReplaceWord(string toReplace, string text, Word.Document wordDoc)
        {
            var range = wordDoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: toReplace, ReplaceWith: text);
        }
    }
}
