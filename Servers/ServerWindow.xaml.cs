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
using Servers.db;

namespace Servers
{
    /// <summary>
    /// Логика взаимодействия для ServerWindow.xaml
    /// </summary>
    public partial class ServerWindow : Window
    {
        
        public ServerWindow()
        {
            InitializeComponent();
            ServerList.ItemsSource = MainWindow.db.Seerver.ToList();
            
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Button_CLick(object sender, RoutedEventArgs e)
        {
            ServerList.SelectedItem = ((Button)sender).DataContext;
            var s = ServerList.SelectedItem;
            MainWindow.db.Seerver.Remove((Seerver)s);
            MessageBox.Show("Сервер удален!");
            MainWindow.db.SaveChanges();
        }
        private void Edit_Button_CLick(object sender, RoutedEventArgs e)
        {            

        }        

        private void Button_Click_Edit(object sender, RoutedEventArgs e)
        {
            AddServerWindow asw = new AddServerWindow();
            this.Close();
            asw.Show();
         }        
    }
}
