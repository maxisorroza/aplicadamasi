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
    
    public partial class ordenempleado
    {
        public int id_ordenemple { get; set; }
        public Nullable<int> id_empleado { get; set; }
        public Nullable<int> id_orden { get; set; }
    
        public virtual empleado empleado { get; set; }
        public virtual orden orden { get; set; }
    }
}