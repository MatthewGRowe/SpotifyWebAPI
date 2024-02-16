namespace SpotifyWebAPI.Models
{
    public class AuthResult
    {       //Recieves response from website!

        //Pasted from JSON on this page https://developer.spotify.com/documentation/general/guides/authorization/code-flow/
        /*
         * {
        "access_token": "NgCXRK...MzYjw",
        "token_type": "Bearer",
        "scope": "user-read-private user-read-email",
        "expires_in": 3600,
        "refresh_token": "NgAagA...Um_SHo"
        }*/

        //Generated from the JSON above!
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
    }

}

