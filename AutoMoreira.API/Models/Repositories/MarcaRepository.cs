using AutoMoreira.API.Context;
using AutoMoreira.API.Models.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Repositories
{
    public class MarcaRepository: IMarcaRepository
    {
        private readonly AutoMoreiraContext _context;
        public MarcaRepository(AutoMoreiraContext context)
        {
            _context = context;
        }

        public async Task<Marca[]> GetAllMarcasAsync()
        {
            IQueryable<Marca> query = _context.Marcas;

            query = query.AsNoTracking().OrderBy(v => v.MarcaId);

            return await query.ToArrayAsync();
        }

        public async Task<Marca> GetMarcaByIdAsync(int Id)
        {
            IQueryable<Marca> query = _context.Marcas;


            query = query.AsNoTracking().OrderBy(p => p.MarcaId)
                         .Where(p => p.MarcaId == Id);

            return await query.FirstOrDefaultAsync();
        }

    }
}
