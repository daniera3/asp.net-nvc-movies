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
    
    public partial class movieimg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public movieimg()
        {
            this.Movie = new HashSet<Movie>();
        }
    
        public int idimg { get; set; }
        public string img { get; set; }
        public string title { get; set; }
        public string alt { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movie> Movie { get; set; }
    }
}
