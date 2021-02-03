using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities
{
    public class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int permissionId { get; set; }

        [Required]
        [StringLength(100)]
        public string permissionName { get; set; }

        [Required]
        [StringLength(100)]
        public string permissionCode { get; set; } 
        
        public ICollection<DesignationPermission> designationPermissions { get; set; }

    }
}