using JSONToDatabaseReader.Datamodel;
using JSONToDatabaseReader.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JSONDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IRepository<Song> _context;

        public ArtistsController(IRepository<Song> context)
        {
            _context = context;
        }

        // GET: api/Artists?search=filter
        [HttpGet]
        public IEnumerable<string> Get([FromQuery(Name = "search")] string filter = null)
        {
            var queryable = _context.GetQueryable();
            if (filter != null)
            {
                return queryable.Where(x => x.Artist.Contains(filter) || x.Genre.Contains(filter)).Select(x => x.Artist);
            }
            return queryable.Select(x => x.Artist);
        }
    }
}
