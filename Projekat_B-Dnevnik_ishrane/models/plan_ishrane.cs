namespace Projekat_B_Dnevnik_ishrane.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dnevnik_ishrane.plan_ishrane")]
    public partial class plan_ishrane
    {
        [Key]
        [Column(Order = 0)]
        public int idPLAN_ISHRANE { get; set; }

        public DateTime DatumVrijeme { get; set; }

        [Required]
        [StringLength(700)]
        public string Opis { get; set; }

        public int TRENER_KORISNIK_idKORISNIK { get; set; }

        public int KANDIDAT_KORISNIK_idKORISNIK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(45)]
        public string Dan { get; set; }

        public virtual kandidat kandidat { get; set; }

        public virtual trener trener { get; set; }
    }
}
