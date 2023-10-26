using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class TipoContacto : BaseEntity
{
    public string NombreTipoContacto { get; set; }
    public ICollection<ContactoPersona> ContactoPersonas { get; set; }
}
