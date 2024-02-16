using SpotifyWebAPI.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SpotifyWebAPI.Services
{
    public class SpotifyAccountService : ISpotifyAccountService
    {
        private readonly HttpClient _httpClient;

        public SpotifyAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;   //Set our internal variable using the parameter (setter)
        }
        public async Task<string> GetToken(string clientID, string clientSecret)
        {
            //I think this next line is used to set up the service, this next line
            //sends 2 parameters "the word token is added to the url https://accounts.spotify.com/api/token <--see token is added!
            var request = new HttpRequestMessage(HttpMethod.Post, "token"); //posts "token" as a word onto the end of the request (which is a url)

            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientID}:{clientSecret}")));

            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"}
            });

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            //Deserialise the response into an object (see AuthResult class)
            var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(responseStream);

            return authResult.access_token;
        }

    }
}
