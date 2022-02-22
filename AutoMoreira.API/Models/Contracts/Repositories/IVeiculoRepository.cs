using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Contracts.Repositories
{
    public interface IVeiculoRepository
    {
        Task<Veiculo[]> GetAllVeiculosAsync();
        Task<Veiculo> GetVeiculoByIdAsync(int VeiculoId);
    }
}
