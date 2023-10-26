using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class RolRepository : GenericRepository<Rol>, IRolRepository
    {
        private readonly farmaciaContext _context;

        public RolRepository(farmaciaContext context) : base(context)
        {
            _context = context;
        }
    }
}