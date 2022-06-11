using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using URL_Shortener_Engine.DTO;
using URL_Shortener_Engine.Models;
using URL_Shortener_Engine.Repository;

namespace URL_Shortener_Engine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Short_UrlController : ControllerBase
    {
       
        private readonly IShort_UrlRepository _short_UrlRepository;
        public Short_UrlController( IShort_UrlRepository short_UrlRepository)
        {
   
            _short_UrlRepository = short_UrlRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Short_Url>>> GetAllShort_UrlAsync()
        {
            List<Short_Url> short_Urls = (List<Short_Url>)await _short_UrlRepository.GetAll();
            return Ok(short_Urls);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Short_Url>> GetByIDAsync(int id)
        {
            var Url =await _short_UrlRepository.GetById(id);
            return Ok(Url);
        }

        [HttpPost]
        public async Task<ActionResult<Short_Url>> AddUrlAsync( Short_Url Url)
        {
            var ShortUrl =await _short_UrlRepository.Insert(Url);
                //_short_UrlRepository.Insert(Url);
            return Ok(ShortUrl);

        }

    }
}
