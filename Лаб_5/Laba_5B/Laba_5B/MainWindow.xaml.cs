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
using System.ComponentModel;
using System.Threading;

namespace Laba_5B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker bgworker;
        private int num = 0;
        private int kost = 0;
        private bool kostil = false;

        public MainWindow()
        {
            InitializeComponent();
            bgworker = new BackgroundWorker();
            bgworker.WorkerReportsProgress = true;
            bgworker.WorkerSupportsCancellation = true;
            bgworker.DoWork += numProcess;
            bgworker.ProgressChanged += lblText;
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            kostil = false;
            bgworker.RunWorkerAsync();
            startBtn.IsEnabled = false;
            stopBtn.IsEnabled = true;
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            kostil = true;
            startBtn.IsEnabled = true;
            stopBtn.IsEnabled = false;
        }

        private void numProcess(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (kostil)
                    break;
                if (num == 100)
                    kost = 1;
                else if (num == 0)
                    kost = 0;
                if (kost == 0)
                    for (; num < 100; num++)
                    {
                        if (kostil)
                            break;
                        bgworker.ReportProgress(num);
                        Thread.Sleep(50);
                    }
                else
                    for (; num > 0; num--)
                    {
                        if (kostil)
                            break;
                        bgworker.ReportProgress(num);
                        Thread.Sleep(50);
                    }
                if (kostil)
                    break;
            }
        }
        private void lblText(object sender, ProgressChangedEventArgs e)
        {
            numLbl.Content = e.ProgressPercentage;

            double percent = Math.Round(((double)e.ProgressPercentage / 100 * 100), 0);

            PBar.Value = percent;
        }
    }
}
