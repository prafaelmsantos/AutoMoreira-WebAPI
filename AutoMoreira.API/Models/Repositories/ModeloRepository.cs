using AutoMoreira.API.Context;
using AutoMoreira.API.Models.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMoreira.API.Models.Repositories
{
    public class ModeloRepository: IModeloRepository
    {
        private readonly AutoMoreiraContext _context;
        public ModeloRepository(AutoMoreiraContext context)
        {
            _context = context;
        }

        public async Task<Modelo[]> GetAllModelosAsync()
        {
            IQueryable<Modelo> query = _context.Modelos;

            query = query.AsNoTracking().OrderBy(m => m.ModeloId);

            return await query.ToArrayAsync();
        }

        public async Task<Modelo> GetModeloByIdAsync(int Id)
        {
            IQueryable<Modelo> query = _context.Modelos;


            query = query.AsNoTracking().OrderBy(p => p.ModeloId)
                         .Where(p => p.ModeloId == Id);

            return await query.FirstOrDefaultAsync();
        }

       
    }
}
