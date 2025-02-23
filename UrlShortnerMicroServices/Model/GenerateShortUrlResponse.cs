namespace UrlShortnerMicroServices.Model
{
    /// <summary>
    /// Response model class for generatShortUrlResponse
    /// </summary>
    public class GenerateShortUrlResponse
    {
        /// <summary>
        /// Instance of string
        /// </summary>
        public string ShortUrl {  get; set; }

        /// <summary>
        /// Instance of string
        /// </summary>

        public string LongUrl { get; set; }

        
    }
}
