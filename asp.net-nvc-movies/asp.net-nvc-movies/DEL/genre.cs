//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace asp.net_nvc_movies.DEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class genre
    {
        public string Namegenre { get; set; }
        public int idmovie { get; set; }
    
        public virtual Movie Movie { get; set; }
    }
}
