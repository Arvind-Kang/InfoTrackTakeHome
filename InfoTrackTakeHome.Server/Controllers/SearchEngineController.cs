using InfoTrackTakeHome.Server.Contexts;
using InfoTrackTakeHome.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InfoTrackTakeHome.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SearchEngineController : ControllerBase
    {
        private readonly ScrapingService _scrapingService;
        private readonly InfoTrackContext _context;
        public SearchEngineController(ScrapingService scrapingService,InfoTrackContext context)
        {
            _scrapingService = scrapingService;
            _context = context;
            
        }

        [HttpGet("GetSearchEngine/{searchPhrase}/{url}")]
        public async Task<IActionResult> Get(string searchPhrase, string url)
        {

            string resultPositions;

            try
            {
                resultPositions = await _scrapingService.GetGoogleSearchResults(searchPhrase, url);
            }
            catch (Exception e)
            {
                return new JsonResult(new
                {
                    Success = "False",
                    error = e.Message
                }); ;
            }

            var searchResult = new SearchResult
            {
                SearchPhrase = searchPhrase,
                Url = url,
                Result = resultPositions,
                SearchDate = DateTime.Now
            };         
            _context.SearchResults.Add(searchResult);
            _context.SaveChanges();

            return new JsonResult(new
            {
                Success = "True",
                Positions = resultPositions
            });
        }

        [HttpGet("GetHistory/")]
        public JsonResult GetHistory()
        {
            var resultPositions = _context.SearchResults.ToList();
            return new JsonResult(new
            {
                History = resultPositions
            });
        }

    }
}
