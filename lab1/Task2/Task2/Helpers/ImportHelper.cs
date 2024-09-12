using System.IO;
using System.Text.Json;
using Task2.Models;

namespace Task2.Helpers
{
    public static class ImportHelper
    {
        public static async Task<List<LW1User>> ImportUsersFromJsonAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);
            string jsonString = await reader.ReadToEndAsync();
            List<LW1User>? users = JsonSerializer.Deserialize<List<LW1User>>(jsonString);

            if (users == null || users.Count == 0)
            {
                throw new Exception("Невозможно выполнить импорт");
            }
            return users;
        }
    }
}
