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
using System.Threading;
using System.Net;
using System.Net.Sockets;


namespace Laba_2_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int port = 8888;
        //объект, прослушивающий порт
        static TcpListener listener;
        public MainWindow()
        {
            InitializeComponent();
    


        }
  
        public void Count1()
        {

            Dispatcher.BeginInvoke(new Action(() => listBox.Items.Add("коннектионц ")));

            //цикл подключения клиентов


            //принятие запроса на подключение
            TcpClient client = listener.AcceptTcpClient();
            //создание нового потока для обслуживания нового клиента
            Thread clientThread = new Thread(() => Process(client));
            clientThread.Start();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //создание нового потока из функции Count1
            //создание объекта для отслеживания сообщений
            //переданных с ip адреса через порт
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            //начало прослушивания

            listener.Start();

            Thread myThread1 = new Thread(new ThreadStart(Count1));

            myThread1.Start(); 

           
        }
        //функция, вызываемая в потоке
        public static void Process(TcpClient tcpClient)
        {
            TcpClient client = tcpClient;
            NetworkStream stream = null;
            try
            {
                //получение потока для обмена сообщениями
                stream = client.GetStream();
                // буфер для получаемых данных
                byte[] data = new byte[64];
                //цикл обработки сообщений
               
                    //объект, для формирования строк
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    //до тех пор, пока в потоке есть данные
                    do
                    {
                        //из потока считываются 64 байта и записываются в data
                        bytes = stream.Read(data, 0, data.Length);
                        //из считанных данных формируется строка
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        
                    }
                    while (stream.DataAvailable);
                    //преобразование сообщения
                    
                string message = builder.ToString();
                    //вывод сообщения в консоль сервера
                    
                 //преобразование сообщения в набор байт
                 data = Encoding.Unicode.GetBytes(message);
                    //отправка сообщения обратно клиенту
                    stream.Write(data, 0, data.Length);
                

            }
            catch (Exception ex)
            {
                
            }
           
        }
    





    }
}
