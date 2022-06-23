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

namespace Servers
{
    /// <summary>
    /// Логика взаимодействия для AddServerWindow.xaml
    /// </summary>
    public partial class AddServerWindow : Window
    {
        public AddServerWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(NameServerTB.Text)  || String.IsNullOrWhiteSpace(AdresTB.Text))
            {
                MessageBox.Show("Введите все данные");
            }
            else
            {
                int b = 0;
                db.Seerver serv = new db.Seerver();
                serv.Name_server = NameServerTB.Text;
                serv.Adres = AdresTB.Text;
                
                foreach (var tt in MainWindow.db.Seerver)
                {
                    if (tt.Name_server == NameServerTB.Text || tt.Adres == AdresTB.Text)
                    {
                        b++;
                        MessageBox.Show("Такой номер телефона уже зарегистрирован, введите другой номер");
                    }
                }
                if (b == 0)
                {
                    MainWindow.db.Seerver.Add(serv);
                    MainWindow.db.SaveChanges();
                    MainWindow minwin = new MainWindow();
                    this.Close();
                    minwin.Show();
                }
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            ServerWindow sw = new ServerWindow();
            this.Close();
            sw.Show();
        }
    }
}
