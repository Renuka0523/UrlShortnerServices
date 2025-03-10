﻿using System.ComponentModel.DataAnnotations;
using UrlShortnerMicroServices.Services;

namespace UrlShortnerMicroServices.Model
{
    public class UrlMapping
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ShortUrl { get; set; }= string.Empty;
        [Required]
        public string LongUrl { get; set; }= string.Empty;
    }
}
