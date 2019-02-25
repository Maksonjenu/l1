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


namespace laba_2_4
{

    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int a=0;
        public MainWindow()
        {
            InitializeComponent();
            textBox1.TextChanged += TextBox1_TextChanged;
        }

       

        

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            si.Text = textBox1.Text;
        }
    }
}
