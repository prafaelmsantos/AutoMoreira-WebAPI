using AutoMoreira.API.Models.Contracts.Repositories;
using AutoMoreira.API.Models.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IModeloRepository _modeloRepository;
        public ModeloService(IGeralRepository geralPersist, IModeloRepository modeloPersist)
        {
            _modeloRepository = modeloPersist;
            _geralRepository = geralPersist;
        }
        public async Task<Modelo> AddModelos(Modelo model)
        {
            try
            {
                _geralRepository.Add<Modelo>(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _modeloRepository.GetModeloByIdAsync(model.ModeloId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Modelo> UpdateModelo(int modeloId, Modelo model)
        {
            try
            {
                var modelo = await _modeloRepository.GetModeloByIdAsync(modeloId);
                if (modelo == null) return null;

                model.ModeloId = modelo.ModeloId;

                _geralRepository.Update(model);
                if (await _geralRepository.SaveChangesAsync())
                {
                    return await _modeloRepository.GetModeloByIdAsync(model.ModeloId);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteModelo(int modeloId)
        {
            try
            {
                var modelo = await _modeloRepository.GetModeloByIdAsync(modeloId);
                if (modelo == null) throw new Exception("(Modelo Service) Modelo para apagar não encontrado.");

                _geralRepository.Delete<Modelo>(modelo);
                return await _geralRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Modelo[]> GetAllModelosAsync()
        {
            try
            {
                var modelos = await _modeloRepository.GetAllModelosAsync();
                if (modelos == null) return null;

                return modelos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Modelo> GetModeloByIdAsync(int modeloId)
        {
            try
            {
                var modelos = await _modeloRepository.GetModeloByIdAsync(modeloId);
                if (modelos == null) return null;

                return modelos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       
    }
}
