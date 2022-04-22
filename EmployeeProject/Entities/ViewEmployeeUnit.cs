namespace EmployeeProject.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ViewPersonelBirim")]
    public partial class ViewEmployeeUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonelID { get; set; }

        public int? BirimID { get; set; }

        [StringLength(50)]
        public string AdiSoyadi { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [Column(TypeName = "text")]
        public string Adres { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
        public string BirimAdi { get; set; }
    }
}
