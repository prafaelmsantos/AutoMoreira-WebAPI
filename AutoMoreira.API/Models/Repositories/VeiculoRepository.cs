using AutoMoreira.API.Context;
using AutoMoreira.API.Models.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {

        private readonly AutoMoreiraContext _context;
        public VeiculoRepository(AutoMoreiraContext context)
        {
            _context = context;
        }
        public async Task<Veiculo[]> GetAllVeiculosAsync()
        {
            IQueryable<Veiculo> query = _context.Veiculos;

            query = query.AsNoTracking().Include(x => x.Marca).Include(y => y.Modelo).OrderBy(v => v.VeiculoId);

            return await query.ToArrayAsync();
        }

        public async Task<Veiculo> GetVeiculoByIdAsync(int Id)
        {
            IQueryable<Veiculo> query = _context.Veiculos;


            query = query.AsNoTracking().Include(x => x.Marca).Include(y => y.Modelo).OrderBy(p => p.VeiculoId)
                         .Where(p => p.VeiculoId == Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
