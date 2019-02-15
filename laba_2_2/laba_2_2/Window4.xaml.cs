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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        int ch_year, ch_month, ch_day;
        int[] monthday = new int[12] {31,28,31,30,31,30,31,31,30,31,30,31 };
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
        public Window4()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; //в каждом окне
            this.Closed += MainWindow_Closed;
            
            for (int i = 2019; i > 1949; i--)
            {
                year.Items.Add(i);
            }

            year.SelectedIndex = 0;
            month.Items.Add("Январь");
            month.Items.Add("Февраль");
            month.Items.Add("Март");
            month.Items.Add("Апрель");
            month.Items.Add("Май");
            month.Items.Add("Июнь");
            month.Items.Add("Июль");
            month.Items.Add("Август");
            month.Items.Add("Сентябрь");
            month.Items.Add("Октябрь");
            month.Items.Add("Ноябрь");
            month.Items.Add("Декабрь");

            month.SelectedIndex = 0;
            day.IsEnabled = false;
            tb1.IsEnabled = false;
        }

       

        private void Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            day.Items.Clear();
            string str = year.SelectedItem.ToString();
             ch_year = int.Parse(str);
           if (DateTime.IsLeapYear(ch_year));
            monthday[1] = 29;
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            day.Items.Clear();
            for (int i = 1; i <= monthday[month.SelectedIndex]; i++)
            {
                day.Items.Add(i);
            }
            day.IsEnabled = true;
            
            ch_month = month.SelectedIndex + 1;
        }

        private void Day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
               ch_day = day.SelectedIndex + 1;
               DateTime d2 = DateTime.Today;
            DateTime d1 = new DateTime(ch_year, ch_month, ch_day);
               TimeSpan ts = d2 - d1;
            DateTime ts1 = new DateTime(1, 1, 1);
            ts1 = ts1 + ts;
            tb1.Text = ("Прошло: "+(ts1.Year - 1).ToString() + " лет, " + (ts1.Month - 1).ToString() + " месяцев, " + (ts1.Day - 1).ToString() + " дней ");

        }
    }
}
