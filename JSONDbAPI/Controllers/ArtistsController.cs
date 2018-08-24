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
        private readonly NHibernateRepository<Song> _context;

        public ArtistsController(NHibernateRepository<Song> context)
        {
            _context = context;
        }

        // GET: api/Artists?search=filter
        [HttpGet]
        public IEnumerable<string> Get([FromQuery(Name = "search")] string filter)
        {
            if (filter != null)
            {
                return _context.GetQueryable().Where(x => x.Artist.Contains(filter) || x.Genre.Contains(filter)).Select(x => x.Artist);
            }
            return _context.GetQueryable().Select(x => x.Artist);
        }
    }
}
