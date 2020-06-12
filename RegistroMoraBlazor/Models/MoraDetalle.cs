using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroMoraBlazor.Models
{
    public class MoraDetalle
    {
        [Key]
        public int moraDetalleId { get; set; }
        public int moraId { get; set; }
        public int prestamoId { get; set; }
        public decimal valor { get; set; }

        public MoraDetalle()
        {
            moraDetalleId = 0;
            moraId = 0;
            prestamoId = 0;
            valor = 0;
        }
    }
}
