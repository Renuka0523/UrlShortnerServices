using UrlShortnerMicroServices.Model;

namespace UrlShortnerMicroServices.Services
{
    public class UrlShortnerServices : IUrlShortnerServicescs
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private Random _random = new Random();
        public Task<string?> GetOriginalUrlAsync(string shortCode) 
        {

        }

        public Task<string> ShortenUrlAsync(string originalUrl) 
        {
            //Validation
            //Generate the shortner code
            var shortcode = GenerateShortCode();
            //Add prefix if needed
            var shortUrl = "Newgen.ly" + shortcode;
            var mapping = new UrlMapping();
            mapping.ShortUrl = shortUrl;
            mapping.LongUrl = originalUrl;
            //Add into database
        }

        private string GenerateShortCode (int length = 6) 
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
