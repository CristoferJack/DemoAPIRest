using Dto;
using Dto.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IPersonaService
    {
        Task<ICollection<DtoPersonaResponse>> ListAsync();
        Task<DtoPersonaResponse> GetByIdAsync(int id);
        Task<int> CreateAsync(DtoPersonaRequest request);
        Task<int> UpdateAsync(int id, DtoPersonaRequest request);

        Task DeleteAsync(int id);
    }
}