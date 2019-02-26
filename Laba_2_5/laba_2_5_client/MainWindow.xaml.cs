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
using System.Net.Sockets;
using System.Threading;



namespace laba_2_5_client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string userName;
        public string message;
        const int port = 8888;
        //ip адрес сервера
        const string address = "127.0.0.1";
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Count1()
        {
           
            Dispatcher.BeginInvoke(new Action(() => userName = name.Text));

            //объявление TCP клиента
            TcpClient client = null;
            try
            {
                //создание клиента
                client = new TcpClient(address, port);
                //получение потока для обмена сообщениями
                NetworkStream stream = client.GetStream();
                //цикл обмена сообщениями

                Dispatcher.BeginInvoke(new Action(() => _out.Text += (userName + ": "+" \r  \n")));
                //ввод сообщения
                Dispatcher.BeginInvoke(new Action(() =>  message = _in.Text));
               
                //преобразование сообщение в массив байтов
                byte[] data = Encoding.Unicode.GetBytes(message);
                //отправка сообщения
                stream.Write(data, 0, data.Length);
                //буфер для получаемых данных
                data = new byte[64];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                //до тех пор пока есть данные в потоке
                do
                {
                    //получение 64 байт
                    bytes = stream.Read(data, 0, data.Length);
                    //формирование строки
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);
                Dispatcher.BeginInvoke(new Action(() => message = builder.ToString()));
                Dispatcher.BeginInvoke(new Action(() => _out.Text += ("Сервер:" + message)));
            }

            catch (Exception ex)
            {

            }
            finally
            {
                client.Close();
            }
        }
        private void St_Click(object sender, RoutedEventArgs e)
        {
            Thread myThread1 = new Thread(new ThreadStart(Count1));
            myThread1.Start();
           
        }
    }
    
}
