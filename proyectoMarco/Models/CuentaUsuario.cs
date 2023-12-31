//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyectoMarco.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CuentaUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuentaUsuario()
        {
            this.Direccion1 = new HashSet<Direccion>();
            this.Ventas = new HashSet<Ventas>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public string contraseñaAntigua { get; set; }
        public string direccion { get; set; }
        public bool habilitacionCuenta { get; set; }
        public string numeroFijo { get; set; }
        public string numeroTelefono { get; set; }
        public bool eliminar { get; set; }
        public Nullable<System.DateTime> fechaEliminacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Direccion> Direccion1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
