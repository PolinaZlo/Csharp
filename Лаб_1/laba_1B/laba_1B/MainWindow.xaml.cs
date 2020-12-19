using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace laba_1B
{
    enum Statement
    {
        UP,DOWN,OPEN,CLOSED
    }

    class Lift
    {
        private int curFloor = 1;
        public Statement statement = Statement.OPEN;

        MainWindow mw;
        public Lift(MainWindow mw)
        {
            this.mw = mw;
        }

        public int getFloor
        {
            get { return curFloor; }
            set { curFloor = value; }
        }

        public void moveUp()
        {
            statement = Statement.UP;
            mw.statementLabel.Content = "Лифт едет вверх";
        }

        public void moveDown()
        {
            statement = Statement.DOWN;
            mw.statementLabel.Content = "Лифт едет вниз";
        }
    }

    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer;
        private Lift lift;
        int selectedFloor;
        private int Floors = 0;
        public MainWindow()
        {
            InitializeComponent();
            lift = new Lift(this);

            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);

            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            if (lift.statement == Statement.UP) lift.getFloor++;
            else if (lift.statement == Statement.DOWN) lift.getFloor--;
            curLabel.Content = "Текущий этаж: " + lift.getFloor.ToString();
            if (lift.getFloor == selectedFloor)
            {
                lift.statement = Statement.OPEN;
                selectBox.IsEnabled = true;
                innerButton.IsEnabled = true;
            }
            statementLabel.Content = "Состояние: " + lift.statement.ToString();
        }


        private void insideClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Floors = Convert.ToInt32(floorBox.Text);
                if (Floors < 2 || Floors > 99)
                {
                    MessageBox.Show("Неверный ввод данных!");
                }
                else
                {
                    frontLayer.Visibility = Visibility.Hidden;
                    floorLabel.Content += " " + Floors.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                floorBox.Text = "2";
            }
        }

        private void rideClick(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedFloor = Convert.ToInt32(selectBox.Text);
                if (selectedFloor > Floors || selectedFloor < 1)
                {
                    MessageBox.Show("Вы ввели несуществующий этаж");
                }
                else
                {
                    selectBox.IsEnabled = false;
                    innerButton.IsEnabled = false;
                    lift.statement = Statement.CLOSED;
                    if (selectedFloor > lift.getFloor)
                        lift.moveUp();
                    else if (selectedFloor < lift.getFloor)
                        lift.moveDown();
                    else
                        MessageBox.Show("Лифт находится на этом этаже");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                selectBox.Text = "1";
            }
        }
    }
}
