namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CONFIG_TYPE
    {
        public int Id { get; set; }

        [StringLength(20)]
       
        public string NAME { get; set; }

        [StringLength(10)]
        public string TYPE { get; set; }

        public int? STATYS { get; set; }

        [StringLength(20)]
        public string REMARK { get; set; }
    }
}
