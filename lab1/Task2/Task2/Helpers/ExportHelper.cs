using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Helpers
{
    public static class ExportHelper
    {
        public static async Task ExportUsersToJsonAsync(List<LW1User> users, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            await writer.WriteAsync(JsonSerializer.Serialize(users));
        }
    }
}
