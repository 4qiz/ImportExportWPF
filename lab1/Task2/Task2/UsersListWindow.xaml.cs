﻿using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using Task2.Data;
using Task2.Helpers;
using Task2.Models;
using Task2.Repositories;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для UsersListWindow.xaml
    /// </summary>
    public partial class UsersListWindow : Window
    {
        public ObservableCollection<AppUser> Users { get; set; } = [];

        public UsersListWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private async void ImportUsersFromJsonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JSON files (*.json)|*.json";
                if (openFileDialog.ShowDialog() == false)
                {
                    return;
                }

                string filePath = openFileDialog.FileName;
                var users = await ImportHelper.ImportUsersFromJsonAsync(filePath);
                await UsersRepository.AddRangeAsync(users);
                await ShowUsersAsync();

                MessageBox.Show($"Успешный импорт👍👍👍", "🐈🐈🐈", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ExportUsersToJsonButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var users = await UsersRepository.GetAllAsync();
                
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;
                    await ExportHelper.ExportUsersToJsonAsync(users, filePath);

                    MessageBox.Show($"Успешный экспорт", "😺😺😺", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ShowUsersAsync();
        }

        private async Task ShowUsersAsync()
        {
            Users.Clear();
            var users = await UsersRepository.GetAllAsync();

            foreach (AppUser user in users)
            {
                Users.Add(user);
            }
        }

        private async void ReloadListViewButton_Click(object sender, RoutedEventArgs e)
        {
            await ShowUsersAsync();
        }
    }
}
