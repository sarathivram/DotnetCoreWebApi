using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ascend.Data.Entities
{
    public partial class User 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        [Required]
        [StringLength(50)]
        public string userCode { get; set; }
        [Required]
        [StringLength(50)]
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nativeName { get; set; }
        public string gender { get; set; }
        public DateTime doj { get; set; }
        public DateTime dob { get; set; }
        public string phoneNumber { get; set; }
        
        [StringLength(500)]
        public string userPassword { get; set; }
        
        public int companyId { get; set; }
        
        public int nationality { get; set; }    
        
        [ForeignKey("companyId")]
        public Company company { get; set; }
        
        public int? departmentId { get; set; }
        
        public int? designationId { get; set; }
        
        [ForeignKey("designationId")]
        public Designation designation { get; set; }

        [ForeignKey("departmentId")]
        public Department department { get; set; }
        
    }
}
