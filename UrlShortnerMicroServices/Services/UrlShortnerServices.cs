using UrlShortnerMicroServices.Model;
using Microsoft.EntityFrameworkCore;
using System;
using UrlShortnerMicroServices.Data;



namespace UrlShortnerMicroServices.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UrlShortnerServices : IUrlShortnerServicescs
    {
        private UrlShortenerContext _context = new UrlShortenerContext();

        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        
        private Random _random = new Random();

      /// <summary>
      /// Retrive the orignal url associted with the given short url
      /// </summary>
      /// <param name="shortUrl">Instance of string indicating the short url</param>
      /// <returns>The orignal url if found; otherwise null.</returns>

        public  async Task<string?> GetOriginalUrlAsync(string shortUrl) 
        {
            var response = await _context.UrlMappings.FirstOrDefaultAsync(s => s.ShortUrl == shortUrl);
            if (response != null)
            {
                return response.LongUrl;
            }
            return null;


        }

        /// <summary>
        /// Shortens an orignal url by generating a unique code and string into database
        /// </summary>
        /// <param name="originalUrl">Instance of string indicating the short url</param>
        /// <returns>The newly genrated short url</returns>
        public  async Task<string> ShortenUrlAsync(string originalUrl)
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

            var response = await _context.UrlMappings.AddAsync(mapping);

            await _context.SaveChangesAsync();
            return response.Entity.ShortUrl;
        }
       
       

        private string GenerateShortCode (int length = 6) 
        {
            return new string(Enumerable.Repeat(Alphabet, length).Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
