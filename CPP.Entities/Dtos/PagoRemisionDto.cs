﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CPP.Entities.Dtos
{
    public class PagoRemisionDto
    {
        public int orden_id { get; set; }
        public string numero_remision { get; set; }
        public string proveedor { get; set; }
        public DateTime fecha_alta { get; set; }
        public DateTime fecha_credito { get; set; }
        public string usuario_alta { get; set; }
        public string forma_pago { get; set; }
        public DateTime fecha_pago { get; set; }
        public string sucursal { get; set; }
        public string banco { get; set; }
        public string numero_cheque { get; set; }
        public string numero_transferencia { get; set; }
        public string persona_recibe { get; set; }
        public string persona_autoriza { get; set; }

    }
}