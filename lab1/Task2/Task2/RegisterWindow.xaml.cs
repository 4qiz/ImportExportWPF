using System.Windows;
using Task2.Data;
using Task2.Models;
using Task2.Repositories;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string login = loginTextBox.Text;
            string password = passwordBox.Password;
            if (!ValidateData(name, email, login, password, out LW1User? user))
            {
                MessageBox.Show($"Заполните все поля", "👎👎👎", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (await Register(user))
                {
                    MessageBox.Show($"Успешная регистрация", "🐈🐈🐈", MessageBoxButton.OK, MessageBoxImage.Information);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "👎👎👎", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateData(string name, string email, string login, string password, out LW1User? user)
        {
            user = null;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            user = new LW1User
            {
                Name = name,
                Email = email,
                Login = login,
                Password = password
            };
            return true;
        }

        private async Task<bool> Register(LW1User user)
        {
            if (await UsersRepository.UserExistAsync(user.Login))
            {
                return false;
            }

            await UsersRepository.AddAsync(user);

            return true;
        }
    }
}
