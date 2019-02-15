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
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
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
        public Window6()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; //в каждом окне
            this.Closed += MainWindow_Closed;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
           
                dlg.FileName = "";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";
                dlg.ShowDialog();
            System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName);
            string str;
            while ((str = file.ReadLine()) != null)
            {
                lb.Items.Add(str);
            }
            file.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = ""; 
            dlg.DefaultExt = ".txt"; 
            dlg.Filter = "Text documents (.txt)|*.txt"; 
            dlg.ShowDialog();
        }
    }
}
