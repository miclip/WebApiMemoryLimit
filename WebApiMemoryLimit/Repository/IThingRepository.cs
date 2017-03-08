using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebApiMemoryLimit.Models;

namespace WebApiMemoryLimit.Repository
{
    public interface IThingRepository
    {
        Task<IList<Thing>> GetAllAsync();
        Task<Thing> GetAsync(Guid id);

        Task AddAsync(Thing thing);

        Task UpdateAsync(Guid id, Thing thing);

        Task DeleteAsync(Guid id);

        Task AllocateUnmanagedMemory(int size);

        Task AllocateManagedMemory(int size);
    }
}
