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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
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
        public Window1()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; //в каждом окне
            this.Closed += MainWindow_Closed;
            res.IsEnabled = false;
            tb1.IsEnabled = true;
            tb2.IsEnabled = true;

        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            
            int a = int.Parse(tb1.Text);
            int b = int.Parse(tb2.Text);
            res.Text = (a - b).ToString();

        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {

            int a = int.Parse(tb1.Text);
            int b = int.Parse(tb2.Text);
            res.Text = (a + b).ToString();

        }

        private void Ymno_Click(object sender, RoutedEventArgs e)
        {

            int a = int.Parse(tb1.Text);
            int b = int.Parse(tb2.Text);
            res.Text = (a * b).ToString();
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {

            int a = int.Parse(tb1.Text);
            int b = int.Parse(tb2.Text);
            if (b == 0) res.Text = "Ошибка"; else
            res.Text = (Convert.ToDouble(a) / b).ToString();
        }

      
    }
}
