using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int currencyId { get; set; }
        [Required]
        [StringLength(5)]
        public string currencyCode { get; set; }
        [Required]
        [StringLength(200)]
        public string currencyName { get; set; }

        [StringLength(10)]
        public string currencySymbol { get; set; }
    }
}