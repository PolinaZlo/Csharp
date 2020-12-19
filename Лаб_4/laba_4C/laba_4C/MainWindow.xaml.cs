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
using System.Xml;

namespace laba_4C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        /*
         * <Person Age="30">
         *      <Name>
         *          Alex
         *      </Name>
         *      <Surname>
         *          Freedman
         *      </Surname>
         * </Person>
         */
        class Calculator
        {
            private double FirstValue;
            private double SecondValue;

            public double getFirst
            {
                get { return FirstValue; }
                set { FirstValue = value; }
            }

            public double getSecond
            {
                get { return SecondValue; }
                set { SecondValue = value; }
            }

            public double Add()
            {
                return FirstValue + SecondValue;
            }

            public double Minus()
            {
                return FirstValue - SecondValue;
            }

            public double Multiply()
            {
                return FirstValue * SecondValue;
            }

            public double Division()
            {
                try
                {
                    return FirstValue / SecondValue;
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show("Ошибка деления на ноль");
                    return 0;
                }
            }

            public void Clear()
            {
                FirstValue = 0;
                SecondValue = 0;
            }
        }

            private double res = 0;
            private Calculator calculator;
            private int x = 0;
            public MainWindow()
            {
                InitializeComponent();
                calculator = new Calculator();
                //создать документ
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(@"H:/Zlobina P/сироп/4/laba_4C/laba_4C/XMLFile1.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach(XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                  {
                        XmlNode attr = xnode.Attributes.GetNamedItem("age");
                        if (attr != null) MessageBox.Show(attr.Value);
                           // Console.WriteLine(attr.Value);
                   }
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "Name") MessageBox.Show(childnode.InnerText);
                        if (childnode.Name == "Surname") MessageBox.Show(childnode.InnerText);
                    }
                }
            }

            private void PlusBtn_Click(object sender, RoutedEventArgs e)
            {
                minusBtn.IsEnabled = false;
                multiplyBtn.IsEnabled = false;
                divideBtn.IsEnabled = false;
                calculator.getFirst = Convert.ToDouble(screenTB.Text);
                x = 1;
                Clear();
            }

            private void MinusBtn_Click(object sender, RoutedEventArgs e)
            {
                plusBtn.IsEnabled = false;
                multiplyBtn.IsEnabled = false;
                divideBtn.IsEnabled = false;
                calculator.getFirst = Convert.ToDouble(screenTB.Text);
                x = 2;
                Clear();
            }

            private void MultiplyBtn_Click(object sender, RoutedEventArgs e)
            {
                plusBtn.IsEnabled = false;
                minusBtn.IsEnabled = false;
                divideBtn.IsEnabled = false;
                calculator.getFirst = Convert.ToDouble(screenTB.Text);
                x = 3;
                Clear();
            }

            private void DivideBtn_Click(object sender, RoutedEventArgs e)
            {
                plusBtn.IsEnabled = false;
                minusBtn.IsEnabled = false;
                multiplyBtn.IsEnabled = false;
                calculator.getFirst = Convert.ToDouble(screenTB.Text);
                x = 4;
                Clear();
            }

            private void EqualBtn_Click(object sender, RoutedEventArgs e)
            {
                plusBtn.IsEnabled = true;
                minusBtn.IsEnabled = true;
                multiplyBtn.IsEnabled = true;
                divideBtn.IsEnabled = true;
                calculator.getSecond = Convert.ToDouble(screenTB.Text);
                if (x == 1)
                    res = calculator.Add();
                if (x == 2)
                    res = calculator.Minus();
                if (x == 3)
                    res = calculator.Multiply();
                if (x == 4)
                    res = calculator.Division();
                screenTB.Text = res.ToString();
                x = 0;
            }

            private void ClearBtn_Click(object sender, RoutedEventArgs e)
            {
                plusBtn.IsEnabled = true;
                minusBtn.IsEnabled = true;
                multiplyBtn.IsEnabled = true;
                divideBtn.IsEnabled = true;
                calculator.Clear();
                Clear();
                res = 0;
            }
            private void Clear()
            {
                screenTB.Text = "0";
            }

            private void Num_Click(object sender, RoutedEventArgs e)
            {
                if (screenTB.Text == "0" || res != 0)
                {
                    res = 0;
                    screenTB.Text = "";
                }
                screenTB.Text += ((Button)sender).Content;
            }
        }
    }
