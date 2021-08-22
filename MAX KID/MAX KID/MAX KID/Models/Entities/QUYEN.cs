namespace MAX_KID.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        [Key]
        [Column(Order = 0)]
        public int ID_Quyen { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string TenQuyen { get; set; }

        public virtual PHANQUYEN PHANQUYEN { get; set; }
    }
}
