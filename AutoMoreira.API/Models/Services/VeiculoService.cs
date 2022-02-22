using AutoMoreira.API.Models.Contracts.Repositories;
using AutoMoreira.API.Models.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Services
{
    public class VeiculoService: IVeiculoService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IVeiculoRepository _veiculoRepository;


        public VeiculoService(IGeralRepository geralRepository, IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _geralRepository = geralRepository;

        }


        public async Task<Veiculo> AddVeiculos(Veiculo model)
        {
            try
            {
                _geralRepository.Add<Veiculo>(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _veiculoRepository.GetVeiculoByIdAsync(model.VeiculoId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Veiculo> UpdateVeiculo(int veiculoId, Veiculo model)
        {
            try
            {
                var veiculo = await _veiculoRepository.GetVeiculoByIdAsync(veiculoId);
                if (veiculo == null) return null;

                model.VeiculoId = veiculo.VeiculoId;

                _geralRepository.Update(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _veiculoRepository.GetVeiculoByIdAsync(model.VeiculoId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteVeiculo(int veiculoId)
        {
            try
            {
                var veiculo = await _veiculoRepository.GetVeiculoByIdAsync(veiculoId);
                if (veiculo == null) throw new Exception("(Veiculo Service) Veiculo para apagar não encontrado.");

                _geralRepository.Delete<Veiculo>(veiculo);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Veiculo[]> GetAllVeiculosAsync()
        {
            try
            {
                var veiculos = await _veiculoRepository.GetAllVeiculosAsync();
                if (veiculos == null) return null;

                return veiculos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Veiculo> GetVeiculoByIdAsync(int veiculoId)
        {
            try
            {
                var veiculos = await _veiculoRepository.GetVeiculoByIdAsync(veiculoId);
                if (veiculos == null) return null;

                return veiculos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
