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

namespace Servers
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Server_prodEntities db = new Server_prodEntities();

        public static User authUser;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            //seetovar st = new seetovar();
            //mainadmin ac = new mainadmin();
            if(LoginTB.Text == "" || PasswordTB.Text == "")
            {
                MessageBox.Show($"Ошибка, заполните все поля.");
            }
            else
            {
                foreach (var user in db.User)
                {
                    if (user.Login == LoginTB.Text.Trim() && user.Password == PasswordTB.Text.Trim())
                    {
                        MessageBox.Show($"Привет Пользователь {user.Login}");
                        authUser = user;
                        ServerWindow sw = new ServerWindow();
                        this.Close();
                        sw.Show();
                    }
                }
            }            
        }
    }
}
