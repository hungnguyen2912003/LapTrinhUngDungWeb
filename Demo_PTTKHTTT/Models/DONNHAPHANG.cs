//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo_PTTKHTTT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONNHAPHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DONNHAPHANG()
        {
            this.TRONG1 = new HashSet<TRONG1>();
        }
    
        public string MADNH { get; set; }
        public Nullable<bool> TRANGTHAI { get; set; }
        public Nullable<System.DateTime> NGAYLAPDNH { get; set; }
        public Nullable<System.DateTime> NGAYXACNHANDNH { get; set; }
        public Nullable<decimal> TONGTIENDNH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRONG1> TRONG1 { get; set; }
    }
}
