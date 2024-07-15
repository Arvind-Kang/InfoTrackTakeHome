namespace InfoTrackTakeHome.Server.Services
{
    using InfoTrackTakeHome.Server.Contexts;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class ScrapingService
    {
        public async Task<string> GetGoogleSearchResults(string searchPhrase, string url)
        {
            var httpClient = new HttpClient();
            var searchUrl = $"https://www.google.co.uk/search?num=100&q={searchPhrase}";
            var response = await httpClient.GetAsync(searchUrl);
            if(response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                throw new Exception("You are currently being rate limited, please wait before trying again");              
            }
            var responseContents = await response.Content.ReadAsStringAsync();
            var positions = ParseGoogleSearchResults(responseContents, url);

            return positions.Count > 0 ? string.Join(", ", positions) : "0";
        }

        private List<int> ParseGoogleSearchResults(string htmlContent, string targetUrl)
        {
            var positions = new List<int>();
            var pattern = @"<div class=""[a-zA-Z0-9]+ [a-zA-Z0-9]+""><a href=""([^""]+)""[^>]*>(.*?)<\/a><\/div>";
            var matches = Regex.Matches(htmlContent, pattern);
            for (int i = 0; i < matches.Count; i++)
            {
                var href = matches[i].Groups[1].Value;
                if (href.Contains(targetUrl))
                {           
                    positions.Add(i + 1);
                }
            }
            return positions;
        }
    }
}
