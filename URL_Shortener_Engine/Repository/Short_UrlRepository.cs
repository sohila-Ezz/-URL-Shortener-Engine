using Microsoft.EntityFrameworkCore;
using shortid;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using URL_Shortener_Engine.DTO;
using URL_Shortener_Engine.Models;


namespace URL_Shortener_Engine.Repository
{
    public class Short_UrlRepository : IShort_UrlRepository
    {
         readonly ApplicatioDbContext _context;
        private const string ServiceUrl = "http://localhost:8080";
        public Short_UrlRepository(ApplicatioDbContext context)
        {
            _context = context;
        }

        public  Short_Url Delete(int id)
        {
            var Url = _context.ShortUrls.FirstOrDefault(x => x.Id == id);
            if (Url != null)
            {
               _context.Remove(Url);
                _context.SaveChanges();
                return  Url;
            }
            return null;
        }

        public async Task<IEnumerable<Short_Url>> GetAll()
        {
            List<Short_Url>  Urls=  await _context.ShortUrls.ToListAsync();
            return Urls;
        }

        public async Task<Short_Url> GetById(int id)
        {
            Short_Url Url =await _context.ShortUrls.FirstOrDefaultAsync(x => x.Id == id);
             return Url;
        }

        public async Task<Short_Url> Insert(Short_Url item)
        {
            // var newshortCode = ShortId.Generate(length:8);
            var slug = ShortId.Generate();
            Short_Url short_Url = new Short_Url
            {
               
            ShortCode = slug,
            ShortUrl = $"{ServiceUrl}/{slug}",
            OriginalUrl = item.OriginalUrl,
                
            };
           await _context.ShortUrls.AddAsync(short_Url);
            _context.SaveChanges();
             return short_Url;  
        }
        public Short_Url Update(int id, Short_Url item)
        {
            var Url = _context.ShortUrls.FirstOrDefault(x => x.Id == id);
            var slug = ShortId.Generate();
            Url.OriginalUrl = item.OriginalUrl;
            Url.ShortCode = slug;
            Url.ShortUrl = $"{ServiceUrl}/{slug}";
           
            _context.SaveChanges();
            return Url;
        }
       
    }
}
