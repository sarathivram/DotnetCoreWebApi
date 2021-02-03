using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int countryId { get; set; }
        [StringLength(100)]
        [Required]
        public string countryName { get; set; }
        [StringLength(10)]
        public string countryCode { get; set; }
        [StringLength(10)]
        public string callingCode { get; set; }
        public ICollection<Company> company { get; set; }
        public ICollection<State> state { get; set; }
        public ICollection<User> user { get; set; }
    }
}