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
using System.Data.SQLite;

namespace laba_2_4
{
    /// <summary>
    /// Логика взаимодействия для Window_add.xaml
    /// </summary>
    public partial class Window_add : Window
    {
       
       
        public Window_add(string paths)
        {

            
            InitializeComponent();
            
            SQLiteConnection m_dbConnection;
            
            m_dbConnection = new SQLiteConnection("Data Source= " + paths + ";Version=3;");
            m_dbConnection.Open();
            string sql1 = "SELECT uid FROM marks ORDER BY uid DESC LIMIT 1";
            SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
            SQLiteDataReader reader = command1.ExecuteReader();
                int a = 0;
                uid_label.Content = a.ToString();
            while (reader.Read())
            {
                 a = Convert.ToInt32(reader["uid"]) + 1;
                uid_label.Content = a.ToString();
            }
            m_dbConnection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
