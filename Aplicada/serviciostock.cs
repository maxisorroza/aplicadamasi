//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aplicada
{
    using System;
    using System.Collections.Generic;
    
    public partial class serviciostock
    {
        public int id_serviciostock { get; set; }
        public int id_servicio { get; set; }
        public int id_stock { get; set; }
    
        public virtual servicio servicio { get; set; }
        public virtual stock stock { get; set; }
    }
}