using System;
using System.Collections.Generic;

using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using WebApiMemoryLimit.Models;

namespace WebApiMemoryLimit.Repository
{
    public class ThingRepositoryInMemory:IThingRepository
    {
        private static IList<Thing> _things;
        private static IntPtr _hglobal;
        private static IList<byte[]> _bytes;

        public ThingRepositoryInMemory()
        {
            if(_things ==null)
                _things = ThingInitializer.GetThings();
        }

        public async Task AllocateUnmanagedMemory(int size)
        {
            _hglobal = Marshal.AllocHGlobal(size);
            Marshal.FreeHGlobal(_hglobal);

        }

        public async Task AllocateManagedMemory(int size)
        {
           var bytes = new byte[1000 * 1000 * size];
            bytes[0] = 0;

            if(_bytes == null)
                _bytes = new List<byte[]>();

            _bytes.Add(bytes);
        }

        public async Task<IList<Thing>> GetAllAsync()
        {
            return await Task.Run(()=> _things.ToList());
        }

        public async Task<Thing> GetAsync(Guid id)
        {
            return  _things.FirstOrDefault(t => t.Id == id);
        }

        public async Task AddAsync(Thing thing)
        {
            if (thing.Id == Guid.Empty)
                thing.Id = Guid.NewGuid();

             _things.Add(thing);
        }

        public async Task UpdateAsync(Guid id, Thing thing)
        {
            var oldThing = await GetAsync(id);
            oldThing.Name = thing.Name;
            oldThing.Description = thing.Description;
            oldThing.ModifiedDateTime = DateTime.UtcNow;
           
        }

        public async Task DeleteAsync(Guid id)
        {
            var thing = await GetAsync(id);
            _things.Remove(thing);
        }

    }
    
}