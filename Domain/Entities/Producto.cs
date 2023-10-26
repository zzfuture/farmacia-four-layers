using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Producto : BaseEntityVC
{
    public string NombreProducto { get; set; }
    public int IdMarcaFk { get; set; }
    public Marca Marcas { get; set; }
    public ICollection<Inventario> Inventarios { get; set; }
}
