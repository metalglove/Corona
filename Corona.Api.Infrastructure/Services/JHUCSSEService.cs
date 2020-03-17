using Corona.Api.Application.Dtos;
using Corona.Api.Application.Services;
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
    public class JhuCsseService : IJhuCsseService
    {
        private const string JHUCSSE_REPO = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/"; // csse_covid_19_time_series/time_series_19-covid-
        private const string TIMESERIES = "csse_covid_19_time_series/time_series_19-covid-";
        private const string CONFIRMED = TIMESERIES + "Confirmed.csv";
        private const string DEATHS = TIMESERIES + "Deaths.csv";
        private const string RECOVERED = TIMESERIES + "Recovered.csv";

        private readonly Uri _baseAddress;
        private readonly HttpClient _httpClient;

        public JhuCsseService()
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
        public Task<List<ReportDto>> GetLatestDataAsync()
            => GetLatestDataAsync(CancellationToken.None);
        public async Task<List<ReportDto>> GetLatestDataAsync(CancellationToken cancellationToken)
        {
            List<ReportDto> reports = new List<ReportDto>();
            List<DateTime> dates;

            using TextReader confirmedStream = await GetStreamReaderAsync(CONFIRMED, cancellationToken).ConfigureAwait(false);
            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled<List<ReportDto>>(cancellationToken).Result;

            using TextReader recoveredStream = await GetStreamReaderAsync(RECOVERED, cancellationToken).ConfigureAwait(false);
            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled<List<ReportDto>>(cancellationToken).Result;
            
            using TextReader deathsStream = await GetStreamReaderAsync(DEATHS, cancellationToken).ConfigureAwait(false);
            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled<List<ReportDto>>(cancellationToken).Result;

            // dispose headers & capture dates
            CultureInfo usCulture = new CultureInfo("us-US");
            dates = confirmedStream.ReadLine().Split(',').Skip(4).Select(dt => DateTime.Parse(dt, usCulture)).ToList();
            _ = recoveredStream.ReadLine();
            _ = deathsStream.ReadLine();

            string[] confirmed;
            string[] recovered;
            string[] deaths;
            for (int i = 0; i < 463; i++)
            {
                confirmed = SmartSplit(confirmedStream.ReadLine());
                recovered = SmartSplit(recoveredStream.ReadLine());
                deaths = SmartSplit(deathsStream.ReadLine());
                RecordDto record = new RecordDto()
                {
                    Name = confirmed[0],
                    Latitude = Convert.ToSingle(confirmed[2]),
                    Longitude = Convert.ToSingle(confirmed[3]),
                    Data = new List<DataDto>()
                };
                List<int> confirmedValues = confirmed.Skip(4).Select(int.Parse).ToList();
                List<int> recoveredValues = recovered.Skip(4).Select(int.Parse).ToList();
                List<int> deathsValues = deaths.Skip(4).Select(int.Parse).ToList();
                for (int j = 0; j < dates.Count; j++)
                {
                    record.Data.Add(new DataDto() 
                    {
                        Date = dates[j], 
                        Confirmed = confirmedValues[j], 
                        Recovered = recoveredValues[j], 
                        Deaths = deathsValues[j] 
                    });
                }
                ReportDto report = reports.SingleOrDefault(r => r.Id.Equals(confirmed[1]));
                if (report == default)
                {
                    report = new ReportDto() 
                    {
                        Id = confirmed[1], 
                        Records = new List<RecordDto>() { record } 
                    };
                    reports.Add(report);
                }
                else
                    report.Records.Add(record);
            }

            return reports;

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
        }

        private async Task<StreamReader> GetStreamReaderAsync(string requestUri, CancellationToken cancellationToken)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(requestUri, cancellationToken);
            if (!httpResponseMessage.IsSuccessStatusCode)
                return await Task.FromCanceled<StreamReader>(cancellationToken);
            return new StreamReader(await httpResponseMessage.Content.ReadAsStreamAsync());
        }
    }
}
