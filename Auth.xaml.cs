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

namespace ISRPOInv
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        Database1Entities db;
        public Auth()
        {
            InitializeComponent();
            db = new Database1Entities();
        }
        private void Enter(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Auth_Login.Text) || string.IsNullOrWhiteSpace(Auth_Password.Password))
            {
                MessageBox.Show("Вы заполнили не все поля", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var auth_check = db.User.FirstOrDefault(ch => ch.login == Auth_Login.Text && ch.password == Auth_Password.Password);
            if (auth_check == null)
            {
                MessageBox.Show("Логин или пароль введены не верно", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Hide();
                new Inv_window().ShowDialog();
                Application.Current.Shutdown();
            }
        }
    }
}
