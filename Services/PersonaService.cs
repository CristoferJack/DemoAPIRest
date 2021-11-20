using DataAccess;
using Dto;
using Dto.Request;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repository;
        public PersonaService(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<DtoPersonaResponse>> ListAsync()
        {
            var collection = await _repository.ListCollection();

            return collection.Select(x => new DtoPersonaResponse
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Documento = x.Documento,
                Perfil = x.Perfil,
                Salario = x.Salario,
                Edad = x.Edad,
                Email = x.Email,
                Telefono = x.Telefono
            }).ToList();
        }

        public async Task<DtoPersonaResponse> GetByIdAsync(int id)
        {
            var persona = await _repository.GetAsync(id);

            if (persona == null)
                return null;

            return new DtoPersonaResponse
            {
                Id=persona.Id,
                Nombre = persona.Nombre,
                Documento = persona.Documento,
                Perfil = persona.Perfil,
                Salario = persona.Salario,
                Edad = persona.Edad,
                Email = persona.Email,
                Telefono = persona.Telefono
            };
        }

        public async Task<int> CreateAsync(DtoPersonaRequest request)
        {
            return await _repository.CreateAsync(new Persona
            {
                Nombre = request.Nombre,
                Documento = request.Documento,
                Perfil = request.Perfil,
                Salario = request.Salario,
                Edad = request.Edad,
                Email = request.Email,
                Telefono = request.Telefono
            });
        }  

        public async Task<int> UpdateAsync(int id, DtoPersonaRequest request)
        {
            return await _repository.UpdateAsync(new Persona
            {
                Id = id,
                Nombre = request.Nombre,
                Documento = request.Documento,
                Perfil = request.Perfil,
                Salario = request.Salario,
                Edad = request.Edad,
                Email = request.Email,
                Telefono = request.Telefono
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
