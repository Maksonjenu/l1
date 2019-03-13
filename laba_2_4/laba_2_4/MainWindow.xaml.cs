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
using System.Data.SQLite;


namespace laba_2_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

      
        public string db_name = "";
        public class data
        {
            public int uid { get; set; }
            public string fio { get; set; }
            public int math { get; set; }
            public int phys { get; set; }
        }
        List<data> studs = new List<data>();

        public MainWindow()
        {
            InitializeComponent();         
            text_uid.IsReadOnly = true;
            save.IsEnabled = false;
            delete.IsEnabled = false;
            rename.IsEnabled = false;
            addelem.IsEnabled = false;
            text_uid.IsReadOnly = true;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e) //save
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e) //open
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "db_filename";
                dlg.DefaultExt = ".db";
                dlg.Filter = "Databases documents (.db)|*.db";
                dlg.ShowDialog();
                db_name = dlg.FileName;
                if (db_name == "db_filename") { throw new ArgumentException("Не выбрана db"); }
                else
                {
                    path.Content = "Path - "+ dlg.FileName;
                    SQLiteConnection m_dbConnection;
                    m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
                    m_dbConnection.Open();
                    string sql = "SELECT * FROM marks, name WHERE marks.uid = name.uid";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        data st = new data
                        {
                            fio = reader["fio"].ToString(),
                            math = int.Parse(reader["math"].ToString()),
                            phys = int.Parse(reader["phys"].ToString()),
                            uid = int.Parse(reader["uid"].ToString())
                        };
                        studs.Add(st);
                    }
                    somegrid.ItemsSource = studs;
                    somegrid.Items.Refresh();
                    m_dbConnection.Close();
                    save.IsEnabled = true;
                    delete.IsEnabled = true;
                    rename.IsEnabled = true;
                    addelem.IsEnabled = true;
                }
            }
            catch (ArgumentException ex)
            {
                textbox_name.Text = (ex.Message);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //удалить
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql3 = " DELETE FROM name  WHERE uid = " + ((data)somegrid.Items[somegrid.SelectedIndex]).uid + ";" + " DELETE FROM marks  WHERE uid = " + ((data)somegrid.Items[somegrid.SelectedIndex]).uid;
            SQLiteCommand command = new SQLiteCommand(sql3, m_dbConnection);
            command.ExecuteNonQuery();

            studs.RemoveAt(somegrid.SelectedIndex);
            somegrid.Items.Refresh();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //изменить чузен элемент
                                                                        /*  {
                                                                              try
                                                                              {
                                                                                  if (somegrid.SelectedIndex == -1) throw new ArgumentException("Не выбран элемент");
                                                                                  Window_trans trans = new Window_trans(ref studs, studs[somegrid.SelectedIndex].uid, db_name)
                                                                                  {
                                                                                      Owner = this
                                                                                  };
                                                                                  if (trans.ShowDialog() == true)
                                                                                  {
                                                                                      SQLiteConnection m_dbConnection;
                                                                                      m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
                                                                                      m_dbConnection.Open();
                                                                                      string sql1 = "UPDATE name SET fio ='" + trans.tb_fio.Text + "' WHERE uid =" + somegrid.SelectedIndex + "; UPDATE marks SET phys =" + trans.tb_phys.Text + ", math ="+ trans.tb_math.Text + " WHERE uid =" + somegrid.SelectedIndex;
                                                                                      SQLiteCommand command = new SQLiteCommand(sql1, m_dbConnection);
                                                                                      command.ExecuteNonQuery();
                                                                                      studs[somegrid.SelectedIndex].fio = trans.tb_fio.Text;
                                                                                      ((data)somegrid.Items[somegrid.SelectedIndex]).fio = trans.tb_fio.Text;
                                                                                      ((data)somegrid.Items[somegrid.SelectedIndex]).math = int.Parse(trans.tb_math.Text);
                                                                                      ((data)somegrid.Items[somegrid.SelectedIndex]).phys = int.Parse(trans.tb_phys.Text);
                                                                                      somegrid.Items.Refresh();
                                                                                      m_dbConnection.Close();
                                                                                  }
                                                                              }
                                                                              catch (ArgumentException ex)
                                                                              {
                                                                                  MessageBox.Show(ex.Message);
                                                                              }

                                                                          }
                                                                          */

        { }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e) //доюавить
        {
            Window_add adds = new Window_add(db_name);
            adds.Owner = this;
            
            if (adds.ShowDialog() == true)
            {
                SQLiteConnection m_dbConnection;
                m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
                m_dbConnection.Open();
                string sql1 = "SELECT uid FROM marks ORDER BY uid DESC LIMIT 1";
                SQLiteCommand command1 = new SQLiteCommand(sql1, m_dbConnection);
                SQLiteDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    int a = Convert.ToInt32(reader["uid"])+1;
                    adds.uid_label.Content = a.ToString();
                }
                data data_ta = new data();
                data_ta.fio = adds.tb_fio.Text;
                data_ta.phys = Convert.ToInt32(adds.tb_phys.Text);
                data_ta.math = Convert.ToInt32(adds.tb_math.Text);
                data_ta.uid = Convert.ToInt32(adds.uid_label.Content);
                string sql = "INSERT INTO name (uid,  fio ) VALUES (" + data_ta.uid + ",'" + data_ta.fio + "')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                string sql2 = "INSERT INTO  marks ( uid, math, phys ) VALUES (" + data_ta.uid + "," + data_ta.math + "," + data_ta.phys + ")";
                command = new SQLiteCommand(sql2, m_dbConnection);
                command.ExecuteNonQuery();
                data dst = new data();
                dst.fio = adds.tb_fio.Text;
                dst.math = int.Parse(adds.tb_math.Text);
                dst.phys = int.Parse(adds.tb_phys.Text);
                dst.uid = int.Parse(adds.uid_label.Content.ToString());
                studs.Add(dst);
                somegrid.ItemsSource = null;
                somegrid.ItemsSource = studs;
                m_dbConnection.Close();
            }
            
        }

        private void Somegrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (somegrid.SelectedIndex > -1)
            {
               try
                {
                    text_uid.Text = ((data)somegrid.Items[somegrid.SelectedIndex]).uid.ToString();
                    textbox_name.Text = ((data)somegrid.Items[somegrid.SelectedIndex]).fio;
                    text_mark_math.Text = ((data)somegrid.Items[somegrid.SelectedIndex]).math.ToString();
                    text_mark_phys.Text = ((data)somegrid.Items[somegrid.SelectedIndex]).phys.ToString();
                }
                catch
                { }


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source=" + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql3 = " UPDATE name SET fio = '" + textbox_name.Text + "' WHERE uid =" + text_uid.Text + ";" + " UPDATE marks SET math = " + text_mark_math.Text + ", phys =" + text_mark_phys.Text + " WHERE uid =" + text_uid.Text;

            SQLiteCommand command = new SQLiteCommand(sql3, m_dbConnection);

            command.ExecuteNonQuery();



            studs[somegrid.SelectedIndex].fio = textbox_name.Text;
            ((data)somegrid.Items[somegrid.SelectedIndex]).fio = textbox_name.Text;
            ((data)somegrid.Items[somegrid.SelectedIndex]).math = int.Parse(text_mark_math.Text);
            ((data)somegrid.Items[somegrid.SelectedIndex]).phys = int.Parse(text_mark_phys.Text);


            somegrid.Items.Refresh();
            m_dbConnection.Close();
        }
    }
}


/*
  string sql = "INSERT INTO name ( uid ,  fio ) VALUES ( " + text_uid.Text + " , " + textbox_name.Text + " )";
            string sql2 = "INSERT INTO  marks ( uid , math , phys ) VALUES ( " + text_uid.Text + " , " + text_mark_math.Text + " , " + text_mark_phys.Text + " )";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            command = new SQLiteCommand(sql2, m_dbConnection);
            command.ExecuteNonQuery();
 */
/*
  <DataGrid.Columns>
               <DataGridTextColumn Binding="{Binding uid}" ClipboardContentBinding="{x:Null}" Header="uid" CanUserResize="False" Width="40"/>
               <DataGridTextColumn Binding="{Binding fio}" ClipboardContentBinding="{x:Null}" Header="fio" CanUserResize="False" Width="250"/>
               <DataGridTextColumn Binding="{Binding phys}" ClipboardContentBinding="{x:Null}" Header="phys" CanUserResize="False" Width="60"/>
               <DataGridTextColumn Binding="{Binding math}" ClipboardContentBinding="{x:Null}" Header="math" CanUserResize="False" Width="60"/>
           </DataGrid.Columns>
           */