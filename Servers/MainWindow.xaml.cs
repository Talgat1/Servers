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
using Servers.db;

using System.Data.SqlClient;
using System.Data;

namespace Servers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Server_prodEntities1 db = new Server_prodEntities1();

        public static Userr authUser;
        public MainWindow()
        {
            InitializeComponent();
            BindServer();
        }

        public List<Seerver> Ser { get; set; }
        
        private void BindServer()
        {
            var item = db.Seerver.ToList();
            Ser = item;
            DataContext = Ser;
        }

        private void ServerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ServerCB.SelectedItem as Seerver;
        }


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            int b = 0;
            if(LoginTB.Text == "" || PasswordTB.Text == "")
            {
                MessageBox.Show($"Ошибка, заполните все поля.");
            }
            else
            {
                foreach (var user in db.Userr)
                {
                    if (user.Login == LoginTB.Text.Trim() && user.Password == PasswordTB.Text.Trim())
                    {
                        b++;
                        MessageBox.Show($"Привет Пользователь {user.Login}");
                        authUser = user;                        
                    }                    
                }
                if (b == 0)
                {
                    MessageBox.Show($"Неверный логин или пароль. Попробуйте еще раз.");
                }
                else
                {
                    ServerWindow sw = new ServerWindow();
                    this.Close();
                    sw.Show();
                }
            }            
        }
    }
}
