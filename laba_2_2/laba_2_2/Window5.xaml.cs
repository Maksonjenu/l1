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
using System.Windows.Shapes;

namespace laba_2_2
{
    /// <summary>
    /// Логика взаимодействия для Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        int sco = 0;
        int co = 0;
        int hco = 0;
        int mco = 0;
        DateTime dt = new DateTime(1, 1, 1, 0, 0, 0);
        System.Windows.Threading.DispatcherTimer Timer;
        public void MainWindow_Loaded(object sender, EventArgs e) //функцию тоже
        {
            MainWindow main = this.Owner as MainWindow;
            if (main != null)
            {
                main.b1.IsEnabled = false;
                main.b2.IsEnabled = false;
                main.b3.IsEnabled = false;
                main.b4.IsEnabled = false;
                main.b5.IsEnabled = false;
                main.b6.IsEnabled = false;

            }
        }
        public void MainWindow_Closed(object sender, EventArgs e) //функцию тоже
        {
            MainWindow main = this.Owner as MainWindow;
            if (main != null)
            {
                main.b1.IsEnabled = true;
                main.b2.IsEnabled = true;
                main.b3.IsEnabled = true;
                main.b4.IsEnabled = true;
                main.b5.IsEnabled = true;
                main.b6.IsEnabled = true;
            }
        }
        public Window5()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; //в каждом окне
            this.Closed += MainWindow_Closed;
            Timer = new System.Windows.Threading.DispatcherTimer();
            //назначение обработчика события Тик
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            //установка интервала между тиками
            //TimeSpan – переменная для хранения времени в формате часы/минуты/секунды
            Timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            hour.IsChecked = true;
            min.IsChecked = true;
            sec.IsChecked = true;
            co = 00;
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            co++;
            dt = dt.AddSeconds(1);

            //вывод в компонент Label текущей даты и времени
            
            if (sec.IsChecked == true && min.IsChecked == true && hour.IsChecked == true)
            {
                sco = co % 60;
                mco = co / 60;
                hco = (co / 60) / 60;
            }
            else
            if (sec.IsChecked == false && min.IsChecked == false && hour.IsChecked == false)
            {
                sco = 00;
                mco = 00;
                hco = 00;
            }
            else
            if (sec.IsChecked == false && min.IsChecked == false && hour.IsChecked == true)
            {
                sco = 00;
                mco = 00;
                hco = (co / 60) / 60;
            }else
            if (sec.IsChecked == false && min.IsChecked == true && hour.IsChecked == false)
            {
                sco = 00;
                hco = 00;
                mco = co / 60;
              
            }else
            if (sec.IsChecked == false && min.IsChecked == true && hour.IsChecked == true)
            {
                sco = 00;
                mco = co / 60;
                hco = (co / 60) / 60;
            }else
            if (sec.IsChecked == true && min.IsChecked == false && hour.IsChecked == false)
            {
                sco = co ;
                mco = 00;
                hco = 00;

            }
            else
            if (sec.IsChecked == true && min.IsChecked == false && hour.IsChecked == true)
            {
                sco = co % 3600;
                mco = 00;
                hco = (co / 60) / 60;
            }
            else
            if (sec.IsChecked == true && min.IsChecked == true && hour.IsChecked == false)
            {
                sco = co % 60;
                mco = co / 60;
                hco = (co / 60) / 60;
            }
            if (hco < 10) hour1.Text = "0" + hco.ToString();
            else hour1.Text = hco.ToString();
            if (mco < 10) min1.Text = "0" + mco.ToString();
            else min1.Text = mco.ToString();
            if (sco < 10) sec1.Text = "0" + sco.ToString();
            else sec1.Text = sco.ToString();




        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Timer.Start();

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Timer.Stop();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            sco = 00;
            mco = 00;
            hco = 00;
            co = 00;
        }
    }
}


