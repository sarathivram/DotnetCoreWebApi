using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities
{
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int designationId { get; set; }

        [Required]
        [StringLength(100)]
        public string designationName { get; set; }

        [Required]
        public int companyId { get; set; }

        [ForeignKey("companyId")]
        public Company company { get; set; }

        public ICollection<User> users { get; set; }

        public ICollection<DesignationPermission> designationPermissions { get; set; }

    }
}