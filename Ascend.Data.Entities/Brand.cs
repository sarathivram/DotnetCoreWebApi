using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ascend.Data.Entities
{
    public partial class Brand : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int brandId { get; set; }

        [StringLength(50)]
        public string brandName { get; set; }

        public string brandDescription { get; set; }
    }
}