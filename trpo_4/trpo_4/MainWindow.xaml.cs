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

namespace trpo_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool lil_checker(int suspect)
        {
            bool flag = true;
            for (int i = 2; i <= suspect / 2; i++)
            {
                if (suspect % i == 0)
                {
                    flag = false;
                    break;
                }
            }
            return (flag);

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int suspect = Convert.ToInt32(pasta.Text);
                pasta.Text = "";
                if (suspect > 0)
                {
                    if (lil_checker(suspect)) lb.Items.Add(suspect);
                    if (!lil_checker(suspect)) MessageBox.Show("Число не простое");
                }
                else MessageBox.Show("Число не простое");
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
                pasta.Text = "";
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Sav_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "simpl";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            dlg.ShowDialog();
            using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(dlg.FileName))
            {

                for (int i = 0; i < lb.Items.Count; i++)
                    outputFile.WriteLine(lb.Items[i].ToString());

            }
        }

        private void Ope_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";
                dlg.ShowDialog();
                using (System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName))
                {
                    while (!file.EndOfStream)
                    {
                        try
                        {
                            int a = Convert.ToInt32(file.ReadLine());
                            if ((lil_checker(a)) && (a > 0))
                                lb.Items.Add(a);

                        }
                        catch (FormatException ex)
                        {
                            
                        }
                    }

                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lb.Items.Clear();
        }
    }
}
            
            
                
                
                
            
    


