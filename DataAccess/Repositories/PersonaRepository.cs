using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly DemoDbContext _context;

        public PersonaRepository(DemoDbContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Persona>> ListCollection()
        {
            return await _context.Set<Persona>().ToListAsync();
        }

        public async Task<Persona> GetAsync(int id)
        {
            return await _context.Set<Persona>()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Persona persona)
        {
            await _context.Set<Persona>().AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona.Id;
        }

        public async Task<int> UpdateAsync(Persona persona)
        {
            _context.Set<Persona>().Attach(persona);
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return persona.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<Persona>()
                .SingleOrDefaultAsync(p => p.Id == id);

            if(entity != null)
            {
                _context.Set<Persona>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
