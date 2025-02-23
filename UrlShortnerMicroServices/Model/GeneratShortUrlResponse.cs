namespace UrlShortnerMicroServices.Model
{
    /// <summary>
    /// Responce model class for generatShortUrl
    /// </summary>
    public class GeneratShortUrlResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string longUrl {  get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string shortUrl { get; set; }
    }
}
