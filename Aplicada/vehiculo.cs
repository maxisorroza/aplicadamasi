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
    
    public partial class vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public vehiculo()
        {
            this.orden = new HashSet<orden>();
        }
    
        public int id_vehiculo { get; set; }
        public string patente { get; set; }
        public int id_modelo { get; set; }
        public Nullable<int> id_cliente { get; set; }
        public string annio { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual modelo modelo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orden> orden { get; set; }
    }
}