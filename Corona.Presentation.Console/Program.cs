using Corona.Api.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Corona.Presentation.CLI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            JHUCSSEService service = new JHUCSSEService();
            List<Report> reports = await service.GetLatestDataAsync(CancellationToken.None);
            string json = JsonSerializer.Serialize(reports, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(@"data.json", json);
            Console.WriteLine("Done");
            await Task.Delay(-1);
        }
    }
}
