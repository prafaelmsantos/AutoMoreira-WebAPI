using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Contracts.Services
{
    public interface IModeloService
    {
        Task<Modelo> AddModelos(Modelo model);
        Task<Modelo> UpdateModelo(int modeloId, Modelo model);
        Task<bool> DeleteModelo(int modeloId);

        Task<Modelo[]> GetAllModelosAsync();
        Task<Modelo> GetModeloByIdAsync(int modeloId);
       
    }
}
