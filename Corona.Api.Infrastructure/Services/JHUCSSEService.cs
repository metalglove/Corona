using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Corona.Api.Infrastructure.Services
{
    public class JHUCSSEService
    {
        private const string JHUCSSE_REPO = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/"; // csse_covid_19_time_series/time_series_19-covid-
        private const string TIMESERIES = "csse_covid_19_time_series/time_series_19-covid-";
        private const string CONFIRMED = TIMESERIES + "Confirmed.csv";
        private const string DEATHS = TIMESERIES + "Deaths.csv";
        private const string RECOVERED = TIMESERIES + "Recovered.csv";

        private readonly Uri _baseAddress;
        private readonly HttpClient _httpClient;

        public JHUCSSEService()
        {
            Uri.TryCreate(JHUCSSE_REPO, UriKind.RelativeOrAbsolute, out _baseAddress);
            _httpClient = new HttpClient
            {
                BaseAddress = _baseAddress
            };
        }

        // start watching the repo 
        // add listener
        // remove listener
        // stop watching the repo

        public async Task<List<Report>> GetLatestDataAsync(CancellationToken cancellationToken)
        {
            List<Report> reports = new List<Report>();
            List<DateTime> dates;

            using TextReader confirmedStream = await GetStreamReaderAsync(CONFIRMED, cancellationToken);
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<List<Report>>(cancellationToken);

            using TextReader recoveredStream = await GetStreamReaderAsync(RECOVERED, cancellationToken);
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<List<Report>>(cancellationToken);
            
            using TextReader deathsStream = await GetStreamReaderAsync(DEATHS, cancellationToken);
            if (cancellationToken.IsCancellationRequested)
                return await Task.FromCanceled<List<Report>>(cancellationToken);

            // dispose headers & capture dates
            CultureInfo usCulture = new CultureInfo("us-US");
            dates = confirmedStream.ReadLine().Split(',').Skip(4).Select(dt => DateTime.Parse(dt, usCulture)).ToList();
            _ = recoveredStream.ReadLine();
            _ = deathsStream.ReadLine();

            string[] confirmed;
            string[] recovered;
            string[] deaths;
            for (int i = 0; i < 442; i++)
            {
                confirmed = SmartSplit(confirmedStream.ReadLine());
                recovered = SmartSplit(recoveredStream.ReadLine());
                deaths = SmartSplit(deathsStream.ReadLine());
                Record record = new Record(confirmed[0], Convert.ToSingle(confirmed[2]), Convert.ToSingle(confirmed[3]));
                List<int> confirmedValues = confirmed.Skip(4).Select(int.Parse).ToList();
                List<int> recoveredValues = recovered.Skip(4).Select(int.Parse).ToList();
                List<int> deathsValues = deaths.Skip(4).Select(int.Parse).ToList();
                for (int j = 0; j < dates.Count; j++)
                {
                    record.Data.Add(new Data(dates[j], confirmedValues[j], recoveredValues[j], deathsValues[j]));
                }
                Report report = reports.Find(r => r.Name.Equals(confirmed[1]));
                if (report == default)
                {
                    report = new Report(confirmed[1], record);
                    reports.Add(report);
                }
                else
                    report.Records.Add(record);
            }

            static string[] SmartSplit(string line, char separator = ',')
            {
                bool inQuotes = false;
                string token = "";
                List<string> lines = new List<string>();
                for (var i = 0; i < line.Length; i++)
                {
                    char ch = line[i];
                    if (inQuotes)
                    {
                        if (ch == '"')
                        {
                            if (i < line.Length - 1 && line[i + 1] == '"')
                            {
                                i++;
                                token += '"';
                            }
                            else inQuotes = false;
                        }
                        else token += ch;
                    }
                    else
                    {
                        if (ch == '"') inQuotes = true;
                        else if (ch == separator)
                        {
                            lines.Add(token);
                            token = "";
                        }
                        else token += ch;
                    }
                }
                lines.Add(token);
                return lines.ToArray();
            }

            return reports;
        }

        private async Task<StreamReader> GetStreamReaderAsync(string requestUri, CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUri, cancellationToken);
            if (!httpResponseMessage.IsSuccessStatusCode)
                return await Task.FromCanceled<StreamReader>(cancellationToken);
            return new StreamReader(await httpResponseMessage.Content.ReadAsStreamAsync());
        }
    }

    public readonly struct Report
    {
        public string Name { get; }
        public List<Record> Records { get; }

        public Report(string name, Record record)
        {
            Name = name;
            Records = new List<Record>() { record };
        }

        public static bool operator ==(Report a, Report b) => a.Name == b.Name;
        public static bool operator !=(Report a, Report b) => !(a.Name == b.Name);
    }

    public readonly struct Record
    {
        public string Name { get; }
        public List<Data> Data { get; }
        public float Latitude { get; }
        public float Longitude { get; }

        public Record(string name, float latitude, float longitude)
        {
            Name = name;
            Data = new List<Data>();
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public readonly struct Data
    {
        public DateTime Date { get; }
        public int Confirmed { get; }
        public int Deaths { get; }
        public int Recovered { get; }

        public Data(DateTime date, int confirmed, int deaths, int recovered)
        {
            Date = date;
            Confirmed = confirmed;
            Deaths = deaths;
            Recovered = recovered;
        }
    }
}
