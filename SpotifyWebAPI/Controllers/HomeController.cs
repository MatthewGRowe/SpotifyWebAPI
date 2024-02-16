using Microsoft.AspNetCore.Mvc;
using SpotifyWebAPI.Models;
using SpotifyWebAPI.Services;
using System.Diagnostics;


namespace SpotifyWebAPI.Controllers
{
    public class HomeController : Controller
    {
        //Declare global instances, you need these "types" for the params in the constructor
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;
        //Video 12:57!!

        //Here we use params with types specified above
        public HomeController(
            ISpotifyAccountService spotifyAccountService, 
            IConfiguration configuration, 
            ISpotifyService spotifyService) //Params force the loading of these things from the Program.cs lines 6-16
        {
            //Initialise the global instances with the data recieved from the program.cs file
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifyService = spotifyService;

        }



        // GET: HomeController
        public async Task<IActionResult> Index()
        {

            var newReleases = await GetReleases();  //Calls GetReleases ↓↓↓ method below ↓↓↓

            return View(newReleases);  //Returns a "view" which must be handled by the Home/Index.html page
        }

        private async Task<IEnumerable<Release>> GetReleases()
        { 
            try
            {
                //Reads in the key and secret from appsettings.json as arguments.
                //Underscore version taken from line 10!
               var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);
               var newReleases = await _spotifyService.GetNewReleases("GR", 20, token); //Send the token and args to the GetNewReleases method
               return newReleases;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return Enumerable.Empty<Release>();
            }
            
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
