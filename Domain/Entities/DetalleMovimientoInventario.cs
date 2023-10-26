using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DetalleMovimientoInventario : BaseEntity
{
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public string IdInventarioFk { get; set; }
    public Inventario Inventarios { get; set; }
    public string IdMovimientoInventarioFk { get; set; }
    public MovimientoInventario MovimientoInventarios { get; set; }
    public ICollection<Factura> Facturas { get; set; }
}
