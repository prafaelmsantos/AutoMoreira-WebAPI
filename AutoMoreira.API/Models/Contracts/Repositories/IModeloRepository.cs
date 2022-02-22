using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Contracts.Repositories
{
    public interface IModeloRepository
    {
        Task<Modelo[]> GetAllModelosAsync();
        Task<Modelo> GetModeloByIdAsync(int modeloId);
        //Task<Modelo[]> GetModeloByMarcaIdAsync(int marcaId);
    }
}
