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

namespace laba_2_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void MainWindow_Closing(object sender, EventArgs e) //функцию тоже
        {
            
        }
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing; //в каждом окне

        }



        

        private void b_1(object sender, RoutedEventArgs e)
        {
            Window1 ww1 = new Window1();
            ww1.Owner = this;
            ww1.Show();
        }
        private void b_2(object sender, RoutedEventArgs e)
        {
            Window2 ww2 = new Window2();
            ww2.Owner = this;
            ww2.Show();
        }
        private void b_3(object sender, RoutedEventArgs e)
        {
            Window3 ww3 = new Window3();
            ww3.Owner = this;
            ww3.Show();
        }
        private void b_4(object sender, RoutedEventArgs e)
        {
            Window4 ww4 = new Window4();
            ww4.Owner = this;
            ww4.Show();
        }
        private void b_5(object sender, RoutedEventArgs e)
        {
            Window5 ww5 = new Window5();
            ww5.Owner = this;
            ww5.Show();
        }
        private void b_6(object sender, RoutedEventArgs e)
        {
            Window6 ww6 = new Window6();
            ww6.Owner = this;
            ww6.Show();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show("OP SECRET");
        }
    }
}
