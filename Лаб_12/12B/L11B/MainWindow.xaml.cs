using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
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

namespace L11B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        List<Items> list = new List<Items>
        {
            new Items {Name = "Тест1", Id = 1, Price = 1},
            new Items {Name = "Тест2", Id = 2, Price = 2},
            new Items {Name = "Тест3", Id = 3, Price = 3},
            new Items {Name = "Тест4", Id = 4, Price = 4},
            new Items {Name = "Тест5", Id = 5, Price = 5},
            new Items {Name = "Тест6", Id = 6, Price = 6},
        };

        Microsoft.Office.Interop.Excel.Application excel;
        Workbook workBook;
        Worksheet workSheet;
        Range cellRange;

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

        public void Generate(DataTable dt)
        {
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.DisplayAlerts = false;
                excel.Visible = false;
                workBook = excel.Workbooks.Add(Type.Missing);
                workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
                workSheet.Name = "Test";
                System.Data.DataTable tempDt = dt;
                dgData.ItemsSource = tempDt.DefaultView;
                workSheet.Cells.Font.Size = 11;
                int rowcount = 1;
                for (int i = 1; i <= tempDt.Columns.Count; i++)
                {
                    workSheet.Cells[1, i] = tempDt.Columns[i - 1].ColumnName;
                }
                foreach (System.Data.DataRow row in tempDt.Rows)
                {
                    rowcount += 1;
                    for (int i = 0; i < tempDt.Columns.Count; i++)
                    {
                        workSheet.Cells[rowcount, i + 1] = row[i].ToString();
                    }
                }
                cellRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[rowcount, tempDt.Columns.Count]];
                cellRange.EntireColumn.AutoFit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void WriteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Generate(ToDataTable(list));
                workBook.SaveAs(System.IO.Path.Combine(@"C:\Users\zpoli\OneDrive\Рабочий стол", "NewExcel"));
                MessageBox.Show("Смотри файл на рабочем столе");
            }
            catch(Exception error)
            {
                MessageBox.Show(string.Format("Ошибка\n{0}", error.Message));
            }
            finally
            {
                workBook.Close();
                excel.Quit();
            }
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == true)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelBook = excelApp.Workbooks.Open(openFile.FileName, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Worksheet excelSheet = (Worksheet)excelBook.Worksheets.get_Item(1); ;
                Range excelRange = excelSheet.UsedRange;

                string strCellData = "";
                double douCellData;
                int rowCnt = 0;
                int colCnt = 0;

                DataTable dt = new DataTable();
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    string strColumn = "";
                    strColumn = (string)(excelRange.Cells[1, colCnt] as Range).Value2.ToString();
                    dt.Columns.Add(strColumn, typeof(string));
                }

                for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                {
                    string strData = "";
                    for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                    {
                        try
                        {
                            strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Range).Value2;
                            strData += strCellData + "|";
                        }
                        catch (Exception ex)
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Range).Value2;
                            strData += douCellData.ToString() + "|";
                        }
                    }
                    strData = strData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(strData.Split('|'));
                }

                dgData.ItemsSource = dt.DefaultView;

                excelBook.Close(true, null, null);
                excelApp.Quit();
            }
        }
    }
}
