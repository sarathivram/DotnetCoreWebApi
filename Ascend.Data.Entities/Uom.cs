using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities 
{
    public class Uom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uomId{get;set;}

        [Required]
        [StringLength(50)]
        public string uomName{get;set;}
    }
}