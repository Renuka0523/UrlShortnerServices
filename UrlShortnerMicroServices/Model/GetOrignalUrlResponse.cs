namespace UrlShortnerMicroServices.Model
{
    /// <summary>
    /// responce model calss for getorignalUrl
    /// </summary>
    public class GetOrignalUrlResponse : GenerateShortUrlResponse 
    {
        /// <summary>
        /// This will be feild only if any error or entry not present
        /// </summary>
        public string message {  get; set; }
    }
}
