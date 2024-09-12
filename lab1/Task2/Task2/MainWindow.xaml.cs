using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task2.Data;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
          
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            new UsersListWindow().Show();
            return;
            var login = loginTextBox.Text;
            var password = passwordBox.Password;
            if (login.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                MessageBox.Show("заполните все поля");
                return;
            }
            if (Authorize(login, password))
            {
                new UsersListWindow().Show();
                Close();
                return;
            }
            MessageBox.Show("Неверный логин или пароль");
        }

        private bool Authorize(string login, string password)
        {
            using var context = new AppDbContext();
            var user = context.Users.FirstOrDefault(u => u.Login == login);
            if (user == null)
            {
                return false;
            }
         
            if (password.ToString() != user.Password.ToString())
            {
                return false;
            }

            return true;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            var password = passwordBox.Password;
            if(login.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                MessageBox.Show("Заполните поля");
                return;
            }
            if (UserExist(login))
            {
                MessageBox.Show("Пользователь существует");
                return;
            }
            if(Register(login, password))
            {
                MessageBox.Show("Успешно зарегистрирован");
                new UsersListWindow().Show();
                Close();
            }
        }

        private bool UserExist(string login)
        {
            return false;
        }

        private bool Register(string login, string password)
        {
            using var context = new AppDbContext();
            var user = context.Users.FirstOrDefault(u => u.Login == login);
           
         

            return true;
        }
    }
}