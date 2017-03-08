using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;

using WebApiMemoryLimit.Models;
using WebApiMemoryLimit.Repository;

namespace EsuranceTestApi.Controllers
{
    public class ThingController : ApiController
    {
        private readonly IThingRepository _repository;

        public ThingController(IThingRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        public async Task<IEnumerable<Thing>> Get()
        {
            return await _repository.GetAllAsync();
        }

        // GET api/values/5
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var thing = await _repository.GetAsync(id);

            if (thing == null)
                return NotFound();

            return Ok(thing);
        }

        [System.Web.Mvc.HttpPost]
        // POST api/values
        public async Task<Thing> Post([FromBody]Thing thing)
        {
            await _repository.AddAsync(thing);
            return thing;
        }

        // PUT api/values/5
        public async Task Put(Guid id, [FromBody]int memory)
        {
           
            await _repository.AllocateManagedMemory(memory);
        }

        // DELETE api/values/5
        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
