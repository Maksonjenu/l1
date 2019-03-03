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
    /// Логика взаимодействия для Window_trans.xaml
    /// </summary>
    public partial class Window_trans : Window
    {
        public Window_trans(ref List<MainWindow.data> datas, int numb, string paths)
        {
            InitializeComponent();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + paths + ";Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM marks, name WHERE name.uid = " + (numb); //прописывает все значения до конца списка фикси падла 
            SQLiteCommand command1 = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                int a = Convert.ToInt32(reader["uid"])+1;
                lb_uid.Content = "Uid - "+ a.ToString();
                tb_fio.Text = reader["fio"].ToString();
                tb_phys.Text = reader["phys"].ToString();
                tb_math.Text = reader["math"].ToString();
            }
        }

        private void Acept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Deby_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
