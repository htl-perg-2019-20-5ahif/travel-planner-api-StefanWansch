using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelerClassLibrary;

namespace TravelPlanner.Controllers
{
    [Route("api/travelPlan")]
    [ApiController]
    public class TravelerController : ControllerBase
    {
        private  HttpClient client;
       

        public TravelerController(IHttpClientFactory clientfactory)
        {
            client = clientfactory.CreateClient();
        }



        // GET: api/Traveler
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string from, [FromQuery] string to, [FromQuery] string start)
        {

            HttpResponseMessage response = await client.GetAsync("https://cddataexchange.blob.core.windows.net/data-exchange/htl-homework/travelPlan.json");
            var plan = JsonSerializer.Deserialize<List<Traveler>>(await response.Content.ReadAsStringAsync());
            TravelPlan travel = new TravelPlan(plan);
            var result = travel.findNext(from,to,start);
            if(result == "")
            {
                return NotFound();
            }
            return Ok(result);

            



        }

        

        
    }
}
