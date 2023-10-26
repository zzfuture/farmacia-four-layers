using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;
public class PersonaRepository : GenericRepositoryVC<Persona>,IPersonaRepository
{
    private readonly farmaciaContext _context;

    public PersonaRepository(farmaciaContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas
                    .Include(c => c.ContactoPersonas)
                    .Include(c => c.MovimientoInventarios)
                    .ThenInclude(c => c.DetalleMovimientoInventarios)
                    .Include(c => c.Facturas)
                    .Include(c => c.UbicacionPersonas)
                    .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Persona> registros)> GetAllAsync(
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Personas as IQueryable<Persona>;
    
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombrePersona.ToLower().Contains(search)); // If necesary add .ToString() after varQuery
        }
        query = query.OrderBy(p => p.Id);
    
        var totalRegistros = await query.CountAsync();
        var registros = await query
                        .Include(c => c.ContactoPersonas)
                        .Include(c => c.MovimientoInventarios)
                        .Include(c => c.Facturas)
                        .Include(c => c.UbicacionPersonas)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
}
