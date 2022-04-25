namespace Projekat_B_Dnevnik_ishrane.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dnevnik_ishrane.namirnica")]
    public partial class namirnica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public namirnica()
        {
            obroks = new HashSet<obrok>();
        }

        [Key]
        public int idNAMIRNICA { get; set; }

        [Required]
        [StringLength(45)]
        public string Naziv { get; set; }

        public decimal Kolicina { get; set; }

        public decimal KalorijskaVrijednost { get; set; }

        public decimal Proteini { get; set; }

        public decimal Masti { get; set; }

        public decimal UgljikoHidrati { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obrok> obroks { get; set; }
    }
}
