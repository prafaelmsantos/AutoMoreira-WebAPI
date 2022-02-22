using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Contracts.Repositories
{
    public interface IMarcaRepository
    {
        Task<Marca[]> GetAllMarcasAsync();
        Task<Marca> GetMarcaByIdAsync(int marcaId);
    }
}
