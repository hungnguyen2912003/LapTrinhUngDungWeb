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
    
    public partial class TRONG1
    {
        public string MAMH { get; set; }
        public string MADNH { get; set; }
        public Nullable<int> SOLUONGNH { get; set; }
    
        public virtual DONNHAPHANG DONNHAPHANG { get; set; }
        public virtual MATHANG MATHANG { get; set; }
    }
}
