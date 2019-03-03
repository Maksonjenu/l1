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

namespace DM_Laba1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

      
        private void A_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        static string Vivod(string[] Chto)
        {
            string c = Chto[0];
            for (int l = 1; l < Chto.Length; l++) { c = c + ',' + Chto[l]; }
            return c;
        }

        private void SortA_Click(object sender, RoutedEventArgs e) //предобработка множеств
        {
            try
            {
                int num;
                if (tb1.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb1.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNuma = int.TryParse(tb1.Text, out num);
                if (isNuma) throw new ArgumentException("Вы долбаеб это не букавы");
                if (tb2.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb2.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNumb = int.TryParse(tb2.Text, out num);
                if (isNumb) throw new ArgumentException("Вы долбаеб это не букавы");

                string[] a = tb1.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] b = tb2.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string temp; int i = 0, j = 0;
                Encoding enc = Encoding.UTF8;
                a = a.Distinct().ToArray(); tb1.Text = Vivod(a);
                b = b.Distinct().ToArray(); tb2.Text = Vivod(b);

                for (i = 0; i < a.Length; i++)
                {
                    byte[] bytesI = enc.GetBytes(a[i]);
                    for (j = i + 1; j < a.Length - 1; j++)
                    {
                        byte[] bytesJ = enc.GetBytes(a[j]);
                        if (bytesI[0] > bytesJ[0])
                        {
                            temp = a[i];
                            a[i] = a[j];
                            a[j] = temp;
                        }
                    }
                }
                for (i = 0; i < b.Length; i++)
                {
                    byte[] bytesI = enc.GetBytes(b[i]);
                    for (j = i + 1; j < b.Length; j++)
                    {
                        byte[] bytesJ = enc.GetBytes(b[j]);
                        if (bytesI[0] > bytesJ[0])
                        {
                            temp = b[i];
                            b[i] = b[j];
                            b[j] = temp;
                        }
                    }
                }
                tb1.Text = Vivod(a);
                tb2.Text = Vivod(b);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        ///////////////////////////////__ОБЪЕДИНЕНИЕ__/////////////////////////////////////////////////////
        private void Obedinenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if (tb1.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb1.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNuma = int.TryParse(tb1.Text, out num);
                if (isNuma) throw new ArgumentException("Вы долбаеб это не букавы");
                if (tb2.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb2.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNumb = int.TryParse(tb2.Text, out num);
                if (isNumb) throw new ArgumentException("Вы долбаеб это не букавы");
                string[] a = tb1.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] b = tb2.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var result = a.Union(b); string c = "";
                foreach (string s in result)
                {
                    c = c + s + ',';
                }
                res.Text = (c).ToString();
            }
            catch (ArgumentException ex)
            { MessageBox.Show(ex.Message); }
        }

        ///////////////////////////////__ПЕРЕСЕЧЕНИЕ__////////////////////////////////////////////
        private void Peresechenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if (tb1.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb1.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNuma = int.TryParse(tb1.Text, out num);
                if (isNuma) throw new ArgumentException("Вы долбаеб это не букавы");
                if (tb2.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb2.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNumb = int.TryParse(tb2.Text, out num);
                if (isNumb) throw new ArgumentException("Вы долбаеб это не букавы");
                string[] a = tb1.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] b = tb2.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var result = a.Intersect(b); string c = "";
                foreach (string s in result)
                {
                    c = c + s + ',';
                }
                res.Text = (c).ToString();
            }
            catch (ArgumentException ex)
            { MessageBox.Show(ex.Message); }

        }

        ///////////////////////////////__РАЗНОСТЬ__/////////////////////////////////////////////
        private void AMinusB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if (tb1.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb1.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNuma = int.TryParse(tb1.Text, out num);
                if (isNuma) throw new ArgumentException("Вы долбаеб это не букавы");
                if (tb2.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb2.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNumb = int.TryParse(tb2.Text, out num);
                if (isNumb) throw new ArgumentException("Вы долбаеб это не букавы");
                string[] a = tb1.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] b = tb2.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var result = a.Except(b); string c = "";
                foreach (string s in result)
                {
                    c = c + s + ',';
                }
                res.Text = (c).ToString();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                
            }

        }
        ///////////////////////////////__ПОДМНОЖЕСТВО__///////////////////////////////////////////////____ВСЕ РАБОТАЕТ
        private void APodmnozestvo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if (tb1.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb1.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNuma = int.TryParse(tb1.Text, out num);
                if (isNuma) throw new ArgumentException("Вы долбаеб это не букавы");
                if (tb2.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb2.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNumb = int.TryParse(tb2.Text, out num);
                if (isNumb) throw new ArgumentException("Вы долбаеб это не букавы");
                string[] a = tb1.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] b = tb2.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Encoding enc = Encoding.UTF8;
                if (a.Length > b.Length) MessageBox.Show("А не является подмножеством В.");
                int i = 0; int j = 0;
                while ((i != a.Length) && (j != b.Length))
                {
                    byte[] bytesI = enc.GetBytes(a[i]);
                    byte[] bytesJ = enc.GetBytes(b[j]);
                    if (bytesI[0] >= bytesJ[0])
                    {
                        if (bytesI[0] > bytesJ[0]) { j++; }
                        if (bytesI[0] == bytesJ[0]) { i++; j++; }
                    }
                }
                if (i == a.Length) MessageBox.Show("А является подмножеством В.");
                else MessageBox.Show("А не является подмножеством В.");
            }
            catch (ArgumentException ex)
            { MessageBox.Show(ex.Message); }
        }

        private void BPodmnozestvo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if (tb1.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb1.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNuma = int.TryParse(tb1.Text, out num);
                if (isNuma) throw new ArgumentException("Вы долбаеб это не букавы");
                if (tb2.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb2.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNumb = int.TryParse(tb2.Text, out num);
                if (isNumb) throw new ArgumentException("Вы долбаеб это не букавы");
                string[] a = tb1.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] b = tb2.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Encoding enc = Encoding.UTF8;
                if (b.Length > a.Length) MessageBox.Show("B не является подмножеством A.");
                int i = 0; int j = 0;
                while ((i != a.Length) && (j != b.Length))
                {
                    byte[] bytesJ = enc.GetBytes(a[i]);
                    byte[] bytesI = enc.GetBytes(b[j]);
                    if (bytesI[0] >= bytesJ[0])
                    {
                        if (bytesI[0] > bytesJ[0]) { j++; }
                        if (bytesI[0] == bytesJ[0]) { i++; j++; }
                    }
                }
                if (i == b.Length) MessageBox.Show("B является подмножеством A.");
                else MessageBox.Show("B не является подмножеством A.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BMinusA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if (tb1.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb1.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNuma = int.TryParse(tb1.Text, out num);
                if (isNuma) throw new ArgumentException("Вы долбаеб это не букавы");
                if (tb2.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb2.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNumb = int.TryParse(tb2.Text, out num);
                if (isNumb) throw new ArgumentException("Вы долбаеб это не букавы");
                string[] a = tb1.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] b = tb2.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var result = b.Except(a); string c = "";
                foreach (string s in result)
                {
                    c = c + s + ',';
                }
                res.Text = (c).ToString();
            }
            catch (ArgumentException ex)
            { MessageBox.Show(ex.Message); }
        }

        private void Delta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num;
                if (tb1.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb1.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNuma = int.TryParse(tb1.Text, out num);
                if (isNuma) throw new ArgumentException("Вы долбаеб это не букавы");
                if (tb2.Text == "") throw new ArgumentException("Вы долбаеб букавы не написал");
                if (tb2.Text == " ") throw new ArgumentException("Вы долбаеб букавы не написал");
                bool isNumb = int.TryParse(tb2.Text, out num);
                if (isNumb) throw new ArgumentException("Вы долбаеб это не букавы");
                string[] a = tb1.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string[] b = tb2.Text.Split(new Char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var result1 = a.Except(b);
                var result2 = b.Except(a);
                var result = result2.Union(result1); string c = "";
                foreach (string s in result)
                {
                    c = c + s + ',';
                }
                res.Text = (c).ToString();
            }
            catch (ArgumentException ex)
            { MessageBox.Show(ex.Message); }
        }
    }
        }

//////////////Проверка на равенство множеств////////////
/*
byte[] a = Encoding.Default.GetBytes(tb1.Text);
byte[] b = Encoding.Default.GetBytes(tb2.Text);
            if (a.SequenceEqual(b))
                MessageBox.Show("А = В");
            else
                MessageBox.Show("А != В");
*/