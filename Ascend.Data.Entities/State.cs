using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities
{
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stateId { get; set; }

        [Required]
        [StringLength(100)]
        public string stateName { get; set; }
        
        [Required]
        public int countryId { get; set; }

        [ForeignKey("countryId")]
        public Country country { get; set; }
    }
}