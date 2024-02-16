namespace SpotifyWebAPI.Services
{
   public interface ISpotifyAccountService  //<--Add the word public!!!
    {

        //Token uses clientID and clientSecret which are given by Spotify when you 
        //log into the Spotify development area and create a new app
        Task<string> GetToken(string clientID, string clientSecret);


    }

      

    
}
