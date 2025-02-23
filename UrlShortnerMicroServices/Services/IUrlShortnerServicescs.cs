namespace UrlShortnerMicroServices.Services
{
    public interface IUrlShortnerServicescs
    {
        /// <summary>
        /// Method will  performe of the long url provided
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns>It indicating shortner url for given short</returns>
        Task<string> ShortenUrlAsync(string originalUrl);
        /// <summary>
        /// Method will Return the valid long for short Url
        /// </summary>
        /// <param name="shortCode"></param>
        /// <returns>It show long url for given short url</returns>
        Task<string?> GetOriginalUrlAsync(string shortCode);
        
    }
}
