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
    
    public partial class servicio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public servicio()
        {
            this.ordenservicio = new HashSet<ordenservicio>();
            this.serviciostock = new HashSet<serviciostock>();
        }
    
        public int id_servicios { get; set; }
        public string detalle { get; set; }
        public string precio { get; set; }
        public int id_modelo { get; set; }
        public Nullable<int> id_tipo { get; set; }
    
        public virtual modelo modelo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordenservicio> ordenservicio { get; set; }
        public virtual tiposervicio tiposervicio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<serviciostock> serviciostock { get; set; }
    }
}