//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Odgovor
    {
        public int Id { get; set; }
        public Nullable<int> PitanjeId { get; set; }
        public string TekstOdgovora { get; set; }
        public Nullable<bool> Aktivan { get; set; }
        public Nullable<bool> Tocan { get; set; }
        public Nullable<int> BrojOdgovora { get; set; }
    
        public virtual Pitanje Pitanje { get; set; }
    }
}
