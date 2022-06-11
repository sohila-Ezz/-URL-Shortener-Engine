using System.ComponentModel.DataAnnotations;

namespace URL_Shortener_Engine.DTO
{
    public class Creat_Short_Url_DTO
    {
        [Required]
        public string OriginalUrl { get; set; }
       
    }
}
