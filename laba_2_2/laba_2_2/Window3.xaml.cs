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

namespace laba_2_2
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public void MainWindow_Loaded(object sender, EventArgs e) //функцию тоже
        {
            MainWindow main = this.Owner as MainWindow;
            if (main != null)
            {
                main.b1.IsEnabled = false;
                main.b2.IsEnabled = false;
                main.b3.IsEnabled = false;
                main.b4.IsEnabled = false;
                main.b5.IsEnabled = false;
                main.b6.IsEnabled = false;

            }
        }
        public void MainWindow_Closed(object sender, EventArgs e) //функцию тоже
        {
            MainWindow main = this.Owner as MainWindow;
            if (main != null)
            {
                main.b1.IsEnabled = true;
                main.b2.IsEnabled = true;
                main.b3.IsEnabled = true;
                main.b4.IsEnabled = true;
                main.b5.IsEnabled = true;
                main.b6.IsEnabled = true;
            }
        }
        public Window3()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; //в каждом окне
            this.Closed += MainWindow_Closed;
            lb.Items.Add("Меркурий");
            lb.Items.Add("Венера");
            lb.Items.Add("Земля");
            lb.Items.Add("Марс");
            lb.Items.Add("Юпитер");
            lb.Items.Add("Сатурн");
            lb.Items.Add("Уран");
            lb.Items.Add("Нептун");
            tb.IsEnabled = false;
        }

        private void Lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lb.SelectedIndex)
            {
                case 0:
                    tb.Text = ("Меркурий (0,4 а. е. от Солнца) является ближайшей планетой к Солнцу и наименьшей планетой системы (0,055 массы Земли). У планеты нет спутников. ");
                    break;
                case 1:
                    tb.Text = ("Венера близка по размеру к Земле (0,815 земной массы) и, как и Земля, имеет толстую силикатную оболочку вокруг железного ядра и атмосферу (из-за этого Венеру нередко называют «сестрой» Земли)");
                    break;
                case 2:
                    tb.Text = ("Земля является крупнейшей и самой плотной из планет земной группы. У Земли наблюдается тектоника плит. Вопрос о наличии жизни где-либо, кроме Земли, остаётся открытым");
                    break;
                case 3:
                    tb.Text = ("Марс меньше Земли и Венеры (0,107 массы Земли). Он обладает атмосферой, состоящей главным образом из углекислого газа, с поверхностным давлением 6,1 мбар (0,6 % от земного)");
                    break;
                case 4:
                    tb.Text = ("Юпитер обладает массой в 318 раз больше земной, и в 2,5 раза массивнее всех остальных планет, вместе взятых. Он состоит главным образом из водорода и гелия");
                    break;
                case 5:
                    tb.Text = ("Сатурн, известный своей обширной системой колец, имеет несколько схожие с Юпитером структуру атмосферы и магнитосферы");
                    break;
                case 6:
                    tb.Text = ("Уран с массой в 14 раз больше, чем у Земли, является самой лёгкой из планет-гигантов. Уникальным среди других планет его делает то, что он вращается «лёжа на боку»");
                    break;
                case 7:
                    tb.Text = ("Нептун, хотя и немного меньше Урана, более массивен (17 масс Земли) и поэтому более плотный. Он излучает больше внутреннего тепла, но не так много, как Юпитер или Сатурн[6].");
                    break;
            }   
        }
    }
}
