using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities
{
    public class DesignationPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int designationPermissionId { get; set; }

        
        public int? designationId { get; set; }

        
        public int? permissionId { get; set; }

        [Required]
        public int companyId { get; set; }

        [ForeignKey("designationId")]
        public Designation designation { get; set; }

        [ForeignKey("permissionId")]
        public Permission permission { get; set; }

        [ForeignKey("companyId")]
        public Company company { get; set; }

    }
}