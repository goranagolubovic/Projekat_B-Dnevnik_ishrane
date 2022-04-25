namespace Projekat_B_Dnevnik_ishrane.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dnevnik_ishrane.mjerenje")]
    public partial class mjerenje
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TRENER_KORISNIK_idKORISNIK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KANDIDAT_KORISNIK_idKORISNIK { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime DatumVrijeme { get; set; }

        public decimal Tezina { get; set; }

        public virtual kandidat kandidat { get; set; }

        public virtual trener trener { get; set; }
    }
}
