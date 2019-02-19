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
        DateTime dt = new DateTime(1, 1, 1, 0, 0, 0);
        System.Windows.Threading.DispatcherTimer Timer;
        public MainWindow()
        {
            InitializeComponent();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (list_list.SelectedIndex > -1)
            {
                TimeSpan t = dlist[list_list.SelectedValue.ToString()] - DateTime.Now;
                

                lab_res.Content = "";

                
                if ((check_day.IsChecked == false) && (check_hour.IsChecked == true) && (check_min.IsChecked == false) && (check_sec.IsChecked == false))
                {
                    lab_res.Content += ((int)(t.TotalHours)).ToString() + "h";
                }
                if ((check_day.IsChecked == false) && (check_hour.IsChecked == false) && (check_min.IsChecked == true) && (check_sec.IsChecked == false))
                {
                    lab_res.Content += ((int)(t.TotalMinutes)).ToString() + "m";
                }
                if ((check_day.IsChecked == false) && (check_hour.IsChecked == false) && (check_min.IsChecked == false) && (check_sec.IsChecked == true))
                {
                    lab_res.Content += ((int)(t.TotalSeconds)).ToString() + "s";
                }
                if ((check_day.IsChecked == false) && (check_hour.IsChecked == true) && (check_min.IsChecked == true) && (check_sec.IsChecked == true))
                {
                    lab_res.Content += ((int)((t.TotalDays * 24 - t.Minutes / 60 - t.Seconds / 3600))).ToString() + "h : ";
                    lab_res.Content += t.Minutes.ToString() + "m : ";
                    lab_res.Content += t.Seconds.ToString() + "s";
                }
                if ((check_day.IsChecked == false) && (check_hour.IsChecked == true) && (check_min.IsChecked == true) && (check_sec.IsChecked == false))
                {
                    lab_res.Content += ((int)(t.TotalDays * 24 - t.Minutes / 60 - t.Seconds / 3600)).ToString() + "h : ";
                    lab_res.Content += ((int)((t.Minutes + t.Seconds / 60))).ToString() + "m ";
                }
                if ((check_day.IsChecked == false) && (check_hour.IsChecked == false) && (check_min.IsChecked == true) && (check_sec.IsChecked == true))
                {
                    lab_res.Content += ((int)((t.TotalMinutes + t.Hours * 60))).ToString() + "m : ";
                    lab_res.Content += t.Seconds.ToString() + "s";
                }
                if ((check_day.IsChecked == false) && (check_hour.IsChecked == true) && (check_min.IsChecked == false) && (check_sec.IsChecked == true))
                {
                    lab_res.Content += ((int)((t.TotalDays * 24 - t.Minutes / 60 - t.Seconds / 3600))).ToString() + "h : ";
                    lab_res.Content += (t.Minutes * 60 + t.Seconds).ToString() + "s";
                }
                if ((check_day.IsChecked == true) && (check_hour.IsChecked == true) && (check_min.IsChecked == false) && (check_sec.IsChecked == false))
                {
                    lab_res.Content += ((int)t.TotalDays).ToString() + "d : ";
                    lab_res.Content += ((int)((t.TotalDays * 24 - t.Minutes / 60 - t.Seconds / 3600))).ToString() + "h";
                }
                if ((check_day.IsChecked == true) && (check_hour.IsChecked == true) && (check_min.IsChecked == false) && (check_sec.IsChecked == true))
                {
                    lab_res.Content += ((int)t.TotalDays).ToString() + "d : ";
                    lab_res.Content += ((int)((t.TotalDays * 24 - t.Minutes / 60 - t.Seconds / 3600))).ToString() + "h : ";
                    lab_res.Content += (t.Minutes * 60 + t.Seconds).ToString() + "s";

                }
                if ((check_day.IsChecked == true) && (check_hour.IsChecked == true) && (check_min.IsChecked == true) && (check_sec.IsChecked == false))
                {
                    lab_res.Content += ((int)t.TotalDays).ToString() + "d : ";
                    lab_res.Content += ((int)((t.TotalDays * 24 - t.Minutes / 60 - t.Seconds / 3600))).ToString() + "h : ";
                    lab_res.Content += ((int)((t.Minutes + t.Seconds / 60))).ToString() + "m";
                }
                if ((check_day.IsChecked == true) && (check_hour.IsChecked == true) && (check_min.IsChecked == true) && (check_sec.IsChecked == true))
                {
                    lab_res.Content += ((int)t.TotalDays).ToString() + "d : ";
                    lab_res.Content += ((int)((t.TotalDays * 24 - t.Minutes / 60 - t.Seconds / 3600))).ToString() + "h : ";
                    lab_res.Content += ((int)((t.Minutes + t.Seconds / 60))).ToString() + "m : ";
                    lab_res.Content += t.Seconds.ToString() + "s";
                }
                if ((check_day.IsChecked == true) && (check_hour.IsChecked == false) && (check_min.IsChecked == false) && (check_sec.IsChecked == false))
                {
                    lab_res.Content += ((int)t.TotalDays).ToString() + "d";
                }
                if ((check_day.IsChecked == true) && (check_hour.IsChecked == false) && (check_min.IsChecked == false) && (check_sec.IsChecked == true))
                {
                    lab_res.Content += ((int)t.TotalDays).ToString() + "d : ";
                    lab_res.Content += t.Seconds.ToString() + "s";
                }
                if ((check_day.IsChecked == true) && (check_hour.IsChecked == false) && (check_min.IsChecked == true) && (check_sec.IsChecked == false))
                {
                    lab_res.Content += ((int)t.TotalDays).ToString() + "d : ";
                    lab_res.Content += ((int)((t.Minutes + t.Seconds / 60))).ToString() + "m";
                }
                if ((check_day.IsChecked == true) && (check_hour.IsChecked == false) && (check_min.IsChecked == true) && (check_sec.IsChecked == true))
                {
                    lab_res.Content += ((int)t.TotalDays).ToString() + "d : ";
                    lab_res.Content += ((int)((t.Minutes + t.Seconds / 60))).ToString() + "m : ";
                    lab_res.Content += t.Seconds.ToString() + "s";
                }

            }
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
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "date";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();
            list_list.Items.Clear();
            dlist.Clear();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName);
            while ((line = file.ReadLine()) != null)
            {
                string name = line;
                line = file.ReadLine();
                if (line == null) break;
                DateTime dt = DateTime.Parse(line);
                list_list.Items.Add(name);
                dlist.Add(name, dt);
            }
            file.Close();
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e) // сохранить
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "date";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(dlg.FileName))
            {
                foreach (KeyValuePair<string, DateTime> kvp in dlist)
                {
                    outputFile.WriteLine(kvp.Key);
                    outputFile.WriteLine(kvp.Value.ToString());
                }
            }
        }
        private void MenuItem_Click_6(object sender, RoutedEventArgs e) //редактировать
        {
          
        }
        private void MenuItem_Click_7(object sender, RoutedEventArgs e) //удалить
        {
            if (list_list.SelectedIndex > -1)
            {
                dlist.Remove(list_list.SelectedValue.ToString());
                list_list.Items.Remove(list_list.SelectedValue.ToString());
            }
        }

        private void List_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Timer.Start();
        }
    }
}
