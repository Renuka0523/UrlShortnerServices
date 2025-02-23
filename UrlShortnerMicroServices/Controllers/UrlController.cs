using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortnerMicroServices.Model;
using UrlShortnerMicroServices.Services;


namespace UrlShortnerMicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {   
        /// <summary>
        /// Instance of IUrlShortnerServices
        /// </summary>
        private IUrlShortnerServicescs _urlShortnerServicescs;

        public UrlController(IUrlShortnerServicescs urlShortnerServicescs) 
        {
            _urlShortnerServicescs = urlShortnerServicescs;
        }
        /// <summary>
        /// This will provide a short url for given olng url
        /// </summary>
        /// <param name="request">Instance of GernertShortnerInstatnce</param>
        /// <returns>on complition will return the long url with valid statuscode</returns>
        [HttpPost("generatShortnerUrl")]

        public async Task<IActionResult> GereratShortnerUrl([FromQuery] GenratShortnerUrlRequest request) 
        {
            if(string.IsNullOrEmpty(request.longUrl)) 
            {
                return BadRequest("the long url needs to be specified");
            }

            try
            {

                var shortUrl = await _urlShortnerServicescs.ShortenUrlAsync(request.longUrl);
                GenerateShortUrlResponse generateShortUrlResponse = new GenerateShortUrlResponse();
                generateShortUrlResponse.LongUrl = request.longUrl;
                generateShortUrlResponse.ShortUrl = shortUrl;

                return Created(nameof(GereratShortnerUrl), generateShortUrlResponse);
            }
            catch (Exception ex)
            {

                return StatusCode(500,"Internal Server error. Unable to procees request" + ex.Message);
            }
           
         

        }

        /// <summary>
        /// retrives the orignal URL associated with the short URL.
        /// </summary>
        /// <param name="request">Instance of GetOrignalUrlRequest containing the short URL to which find the orignal URL.</param>
        /// <returns>Response with short URL and long URL along with message if not found it will be error message.</returns>

        [HttpPost("getOrignalUrl")]

        

        public async Task<IActionResult> getOrignalUrl([FromBody] GetOrignalUrlRequest request) 
        {
            try
            {
                var LongUrlResponse = await _urlShortnerServicescs.GetOriginalUrlAsync(request.shortUrl);
                GetOrignalUrlResponse getOrignalUrlResponse = new GetOrignalUrlResponse();
                getOrignalUrlResponse.ShortUrl = request.shortUrl;
                getOrignalUrlResponse.LongUrl = LongUrlResponse;

                if (LongUrlResponse == null)
                {
                    getOrignalUrlResponse.message = "Url not present into the database";

                    return NotFound(getOrignalUrlResponse);
                }
                else
                {
                    return Ok(getOrignalUrlResponse);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Interal server error occurd while processing request" + ex.Message);
            }
            
            
        }
        
    }
}
