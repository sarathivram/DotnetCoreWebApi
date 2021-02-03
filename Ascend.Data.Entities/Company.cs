using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string companyCode { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        public string phoneNumber { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [Required]
        public int countryId { get; set; }

        [ForeignKey("countryId")]
        public Country country { get; set; }
    }
}