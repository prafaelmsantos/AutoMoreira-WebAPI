using AutoMoreira.API.Models;
using AutoMoreira.API.Models.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcasController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var marcas = await _marcaService.GetAllMarcasAsync();
                if (marcas == null) return NotFound("Nenhuma marca encontrada.");

                return Ok(marcas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var marca = await _marcaService.GetMarcaByIdAsync(id);
                if (marca == null) return NotFound("Marca por Id não encontrado.");

                return Ok(marca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar marcas. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Marca model)
        {
            try
            {
                var marca = await _marcaService.AddMarcas(model);
                if (marca == null) return BadRequest("Erro ao tentar adicionar marca.");

                return Ok(marca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Marca model)
        {
            try
            {
                var marca = await _marcaService.UpdateMarca(id, model);
                if (marca == null) return BadRequest("Erro ao tentar adicionar marca.");

                return Ok(marca);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar marcas. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _marcaService.DeleteMarca(id) ?
                       Ok("Apagado") :
                       BadRequest("Marca não apagado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar apagar marcas. Erro: {ex.Message}");
            }
        }
    }
}
