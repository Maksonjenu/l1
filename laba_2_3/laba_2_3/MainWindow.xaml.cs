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


namespace laba_2_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<string, DateTime> dlist = new Dictionary<string, DateTime>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e) //добавить
        {
            Window1 ww1 = new Window1();
            ww1.Owner = this;
            
            if (ww1.ShowDialog() == true)
            {
                dlist.Add(ww1.name.Text, new DateTime(ww1.calendar.SelectedDate.Value.Year, ww1.calendar.SelectedDate.Value.Month, ww1.calendar.SelectedDate.Value.Day, int.Parse(ww1.hour.Text), int.Parse(ww1.min.Text), int.Parse(ww1.sec.Text)));
                list_list.Items.Add(ww1.name.Text);
            }
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //файл
        {
            
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e) //таймер
        {
            
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e) // открыть
        {
           
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e) // сохранить
        {
           
        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e) //редактировать
        {
          
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e) //удалить
        {
            
        }

        private void List_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(list_list.SelectedIndex)
            {
                case (0):
                    
                    break;
            }
        }
    }
}
