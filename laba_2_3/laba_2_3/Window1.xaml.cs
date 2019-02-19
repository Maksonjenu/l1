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
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace laba_2_3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string st = (@"Z:\");
        static string[] SearchDirectory(string patch)
        {
            //находим все папки в по указанному пути
            string[] ReultSearch = Directory.GetDirectories(patch);
            //возвращаем список директорий
            return ReultSearch;
        }
        static string[] SearchFile(string patch, string pattern)
        {
            /*флаг SearchOption.AllDirectories означает искать во всех вложенных папках*/
            string[] ReultSearch = Directory.GetFiles(patch, pattern, SearchOption.AllDirectories);
            //возвращаем список найденных файлов соответствующих условию поиска 
            return ReultSearch;
        }
        Dictionary<int, string> palevo = new Dictionary<int, string>();
        public Window1()
        {
            
            InitializeComponent();

            
            
            
           
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Name_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            name.SelectAll();
            
            //ищем все вложенные папки 
            string[] S = SearchDirectory(@"Z:\");
            //создаем строку в которой соберем все пути
            
            foreach (string folderPatch in S)
            {
                //добавляем новую строку в список
                // ListPatch += folderPatch + "\n";
                try
                {
                    //пытаемся найти данные в папке 
                   
                        //добавляем файл в список 
                        lb.Items.Add(SearchFile(@"Z:\", "*.pdf"));
                    
                }
                catch
                {
                }
            }
            //выводим список на экран 
            
        }

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Process.Start((lb.SelectedItem).ToString());
        }
    }
}
