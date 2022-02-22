using AutoMoreira.API.Models.Contracts.Repositories;
using AutoMoreira.API.Models.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Services
{
    public class MarcaService: IMarcaService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IMarcaRepository _marcaRepository;
        public MarcaService(IGeralRepository geralRepository, IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
            _geralRepository = geralRepository;
        }
        public async Task<Marca> AddMarcas(Marca model)
        {
            try
            {
                _geralRepository.Add<Marca>(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _marcaRepository.GetMarcaByIdAsync(model.MarcaId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Marca> UpdateMarca(int marcaId, Marca model)
        {
            try
            {
                var marca = await _marcaRepository.GetMarcaByIdAsync(marcaId);
                if (marca == null) return null;

                model.MarcaId = marca.MarcaId;

                _geralRepository.Update(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _marcaRepository.GetMarcaByIdAsync(model.MarcaId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMarca(int marcaId)
        {
            try
            {
                var marca = await _marcaRepository.GetMarcaByIdAsync(marcaId);
                if (marca == null) throw new Exception("(Marca Service) Marca para apagar não encontrado.");

                _geralRepository.Delete<Marca>(marca);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Marca[]> GetAllMarcasAsync()
        {
            try
            {
                var marcas = await _marcaRepository.GetAllMarcasAsync();
                if (marcas == null) return null;

                return marcas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Marca> GetMarcaByIdAsync(int marcaId)
        {
            try
            {
                var marcas = await _marcaRepository.GetMarcaByIdAsync(marcaId);
                if (marcas == null) return null;

                return marcas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
