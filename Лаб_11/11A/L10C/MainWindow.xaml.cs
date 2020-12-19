using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace L10C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel myView = new ViewModel();
        public enum _chart { pie, area, bar, line, column }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = myView;
            RadioButtonChanged(_chart.pie);
            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(@"http://www.cbr.ru/scripts/XML_val.asp?d=0");
            try
            {
                webReq.AllowAutoRedirect = true;
                webReq.MaximumAutomaticRedirections = 100;
                webReq.CookieContainer = new CookieContainer();
                webReq.Method = "GET";
                Encoding win1251 = Encoding.GetEncoding(1251);
                using (WebResponse response = webReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, win1251))
                        {
                            XDocument xdoc = XDocument.Load(reader);
                            xdoc.Descendants("Item").ToList().ForEach(ex =>
                            {
                                myView.AddValuta(ex.Element("Name").Value, ex.Element("ParentCode").Value);
                            });
                        }
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e) => RadioButtonChanged(_chart.pie);

        private void radioButton2_Click(object sender, RoutedEventArgs e) => RadioButtonChanged(_chart.area);

        private void radioButton3_Click(object sender, RoutedEventArgs e) => RadioButtonChanged(_chart.bar);

        private void radioButton4_Click(object sender, RoutedEventArgs e) => RadioButtonChanged(_chart.line);

        private void radioButton5_Click(object sender, RoutedEventArgs e) => RadioButtonChanged(_chart.column);

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateTime.Today < myCalendar.SelectedDates.Last())
            {
                MessageBox.Show("Неверная дата");
                myCalendar.SelectedDate = DateTime.Today;
                return;
            }
        }

        private void myCalendar_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            if (Mouse.Captured is Calendar || Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
                Mouse.Capture(null);
        }

        private void buttonResult_Click(object sender, RoutedEventArgs e)
        {
            if (myCalendar.SelectedDates.Count <= 1)
            {
                MessageBox.Show("Нужно выбрать несколько дат");
                return;
            }
            if (myView.SelectedValuta == null)
            {
                MessageBox.Show("Нужно выбрать валюту");
                return;
            }

            string d1 = myCalendar.SelectedDates.First().ToString("dd/MM/yyyy");
            string d2 = myCalendar.SelectedDates.Last().ToString("dd/MM/yyyy");
            string uri = $"http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1={d1}&date_req2={d2}&VAL_NM_RQ={myView.SelectedValuta.Code.Trim()}";
                //+ d1 + "&date_req2=" + d2 + "&VAL_NM_RQ=" + myView.SelectedValuta.Code.Trim();
            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(uri);
            Console.WriteLine(uri);
            try
            {
                List<double> valutaList = new List<double>();
                myView.KeyValueCollection.Clear();
                int index = -1;
                webReq.AllowAutoRedirect = true;
                webReq.MaximumAutomaticRedirections = 10;
                webReq.Method = "GET";
                Encoding win1251 = Encoding.GetEncoding(1251);
                using (WebResponse response = webReq.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, win1251))
                        {
                            XDocument xdoc = XDocument.Load(reader);
                            xdoc.Descendants("Record").ToList().ForEach(ex =>
                            {
                                valutaList.Add(double.Parse(ex.Element("Value").Value) / double.Parse(ex.Element("Nominal").Value));
                            });
                            xdoc.Root.Elements().Attributes().Where(c => c.Name == "Date").ToList().ForEach(ax =>
                            {
                                myView.AddKeyValue(ax.Value, valutaList[++index]);
                            });
                        }
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
            bool[] radioBoolList = { (bool)radioButton1.IsChecked, (bool)radioButton2.IsChecked, (bool)radioButton3.IsChecked, (bool)radioButton4.IsChecked, (bool)radioButton5.IsChecked };
            for (int i = 0; i < radioBoolList.Length; i++)
                if (radioBoolList[i] == true)
                    RadioButtonChanged((_chart)i);
        }

        public void RadioButtonChanged(_chart temp)
        {
            if (myChart.Series.Count > 0) myChart.Series.RemoveAt(0);
            if (myView.SelectedValuta != null) myChart.Title = myView.SelectedValuta.Title;
            switch (temp)
            {
                case _chart.pie:
                    PieSeries mySeries1 = new PieSeries();
                    if (myView.SelectedValuta != null) mySeries1.Title = myView.SelectedValuta.Title;
                    mySeries1.IndependentValueBinding = new Binding("Key");
                    mySeries1.DependentValueBinding = new Binding("Currency");
                    mySeries1.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries1);
                    break;
                case _chart.area:
                    AreaSeries mySeries2 = new AreaSeries();
                    if (myView.SelectedValuta != null) mySeries2.Title = myView.SelectedValuta.Title;
                    mySeries2.IndependentValueBinding = new Binding("Key");
                    mySeries2.DependentValueBinding = new Binding("Currency");
                    mySeries2.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries2);
                    break;
                case _chart.bar:
                    BarSeries mySeries3 = new BarSeries();
                    if (myView.SelectedValuta != null) mySeries3.Title = myView.SelectedValuta.Title;
                    mySeries3.IndependentValueBinding = new Binding("Key");
                    mySeries3.DependentValueBinding = new Binding("Currency");
                    mySeries3.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries3);
                    break;
                case _chart.line:
                    LineSeries mySeries4 = new LineSeries();
                    if (myView.SelectedValuta != null) mySeries4.Title = myView.SelectedValuta.Title;
                    mySeries4.IndependentValueBinding = new Binding("Key");
                    mySeries4.DependentValueBinding = new Binding("Currency");
                    mySeries4.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries4);
                    break;
                case _chart.column:
                    ColumnSeries mySeries5 = new ColumnSeries();
                    if (myView.SelectedValuta != null) mySeries5.Title = myView.SelectedValuta.Title;
                    mySeries5.IndependentValueBinding = new Binding("Key");
                    mySeries5.DependentValueBinding = new Binding("Currency");
                    mySeries5.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries5);
                    break;
            }
        }
    }
}
