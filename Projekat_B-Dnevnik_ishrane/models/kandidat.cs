namespace Projekat_B_Dnevnik_ishrane.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dnevnik_ishrane.kandidat")]
    public partial class kandidat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kandidat()
        {
            obroks = new HashSet<obrok>();
            plan_ishrane = new HashSet<plan_ishrane>();
            plan_vjezbanja = new HashSet<plan_vjezbanja>();
            mjerenjes = new HashSet<mjerenje>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KORISNIK_idKORISNIK { get; set; }

        public int TRENER_KORISNIK_idKORISNIK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obrok> obroks { get; set; }

        public virtual korisnik korisnik { get; set; }

        public virtual trener trener { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plan_ishrane> plan_ishrane { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plan_vjezbanja> plan_vjezbanja { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mjerenje> mjerenjes { get; set; }
    }
}
