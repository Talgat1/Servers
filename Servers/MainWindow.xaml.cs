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
        public static Server_prodEntities db = new Server_prodEntities();
        bool showpas = true;
        public List<Seerver> Ser { get; set; }
        public static Userr authUser;
        
        public MainWindow()
        {
            InitializeComponent();
            BindServer();
        }               
        private void BindServer()
        {
            
            var item = db.Seerver.ToList();
            Ser = item;
            DataContext = Ser;
        }

        private void ServerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ServerCB.SelectedItem as Seerver;
            foreach (var ser in db.Seerver)
            {
                if (ser.Name_server == item.Name_server)
                {
                    DoppTB.Text = ser.Adres;
                }
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            int b = 0;
            if(String.IsNullOrWhiteSpace(LoginTB.Text) || String.IsNullOrWhiteSpace(PasswordTB.Password))
            {
                MessageBox.Show($"Ошибка, заполните все поля.");
            }
            else
            {
                foreach (var user in db.Userr)
                {
                    if (user.Login == LoginTB.Text.Trim() && user.Password == PasswordTB.Password.Trim())
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
        private void ShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if(showpas == true)
            {
                passwordTxtBox.Text = PasswordTB.Password;
                PasswordTB.Visibility = Visibility.Collapsed;
                passwordTxtBox.Visibility = Visibility.Visible;
                showpas = false;
            }
            else
            {
                PasswordTB.Password = passwordTxtBox.Text;
                passwordTxtBox.Visibility = Visibility.Collapsed;
                PasswordTB.Visibility = Visibility.Visible;
                showpas = true;
            }           
        }        
        
        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(DoppTB.Text))
            {
                MessageBox.Show($"Ошибка, выберите сервер.");
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
