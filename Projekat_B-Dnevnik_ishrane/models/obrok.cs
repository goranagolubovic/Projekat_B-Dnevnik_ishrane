namespace Projekat_B_Dnevnik_ishrane.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dnevnik_ishrane.obrok")]
    public partial class obrok
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KANDIDAT_KORISNIK_idKORISNIK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NAMIRNICA_idNAMIRNICA { get; set; }

        public decimal Kolicina { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(45)]
        public string TipObroka { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime Datum { get; set; }

        public virtual kandidat kandidat { get; set; }

        public virtual namirnica namirnica { get; set; }
    }
}
