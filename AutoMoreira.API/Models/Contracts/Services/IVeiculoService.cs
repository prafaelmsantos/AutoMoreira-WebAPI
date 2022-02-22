using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Contracts.Services
{
    public interface IVeiculoService
    {
        Task<Veiculo> AddVeiculos(Veiculo model);
        Task<Veiculo> UpdateVeiculo(int veiculoId, Veiculo model);
        Task<bool> DeleteVeiculo(int veiculoId);

        Task<Veiculo[]> GetAllVeiculosAsync();
        Task<Veiculo> GetVeiculoByIdAsync(int veiculoId);
    }
}
