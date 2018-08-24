using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONToDatabaseReader.Datamodel;
using JSONToDatabaseReader.Extensions;
using JSONToDatabaseReader.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JSONDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly NHibernateRepository<Song> _context;

        public SongsController(NHibernateRepository<Song> context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get([FromQuery(Name = "search")] string filter)
        {
            if (filter != null)
            {
                return _context.GetQueryable().Where(x => x.Name.Contains(filter) || x.Genre.Contains(filter)).ToList();
            }
            return _context.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            var song = _context.Get(id);
            if (song != null)
                return song;
            return new NotFoundResult();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Song value)
        {
            _context.Save(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Song value)
        {
            var source = _context.Get(id);
            var target = value;
            source.CopyDeltaProperties(target);
            _context.Update(source);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Delete(id);
        }
    }
}
