using System.Windows;
using Task2.Data;
using Task2.Helpers;
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
            if (!ValidateDataHelper.ValidateRegisterData(name, email, login, password, out AppUser? user))
            {
                MessageBox.Show($"Заполните все поля\nДлина пароля больше 5 символов", "👎👎👎", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private async Task<bool> Register(AppUser user)
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
