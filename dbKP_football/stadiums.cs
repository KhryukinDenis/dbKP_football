//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbKP_football
{
    using System;
    using System.Collections.Generic;
    
    public partial class stadiums
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stadiums()
        {
            this.teams = new HashSet<teams>();
        }
    
        public int S_ID { get; set; }
        public string S_NAME { get; set; }
        public int S_CAPACITY { get; set; }
        public int S_YEAROPENING { get; set; }
        public string S_LOCATIONCITY { get; set; }
        public int L_ID { get; set; }
    
        public virtual leagues leagues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teams> teams { get; set; }
    }
}
