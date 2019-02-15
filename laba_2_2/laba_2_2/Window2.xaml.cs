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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
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
        public Window2()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; //в каждом окне
            this.Closed += MainWindow_Closed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // if (tb1.Text == ("Hit or miss?")) tb1.Text = ("I guess they never miss hum ");
            lt.Items.Add(tb1.Text);
            tb1.Text = ("");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
