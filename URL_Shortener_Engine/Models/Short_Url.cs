using System.ComponentModel.DataAnnotations;

namespace URL_Shortener_Engine.Models
{
    public class Short_Url
    {
        public int Id { get; set; }
        [Required]
        public string OriginalUrl { get; set; }
        public string ShortCode { get; set; }
        public string ShortUrl { get; set; }
    }
}
