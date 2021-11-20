using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IPersonaRepository
    {
        Task<ICollection<Persona>> ListCollection();
        Task<Persona> GetAsync(int id);
        Task<int> CreateAsync(Persona persona);
        Task<int> UpdateAsync(Persona persona);
        Task DeleteAsync(int id);
    }
}