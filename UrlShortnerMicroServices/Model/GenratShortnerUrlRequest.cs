namespace UrlShortnerMicroServices.Model
{
    /// <summary>
    /// request data flow object genertae short url methoid
    /// </summary>
    public class GenratShortnerUrlRequest
    {
        /// <summary>
        /// Instance of string requesting the long url
        /// </summary>
        public string longUrl {  get; set; }
    }
}
