namespace Projekat_B_Dnevnik_ishrane.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dnevnik_ishrane.korisnik")]
    public partial class korisnik
    {
        [Key]
        public int idKORISNIK { get; set; }

        [Required]
        [StringLength(45)]
        public string Ime { get; set; }

        [Required]
        [StringLength(45)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(45)]
        public string KorisnickoIme { get; set; }

        [Required]
        [StringLength(45)]
        public string Lozinka { get; set; }

        public int Godiste { get; set; }

        [Required]
        [StringLength(45)]
        public string Tema { get; set; }

        public virtual kandidat kandidat { get; set; }

        public virtual trener trener { get; set; }
    }
}
