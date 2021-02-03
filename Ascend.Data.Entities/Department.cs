using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Ascend.Data.Entities
{
 public class Department : BaseEntity
 {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int departmentId { get; set; }
        [Required]
        [StringLength(20)]
        public string departmentCode { get; set; }
        [Required]
        [StringLength(100)]
        public string departmentName { get; set; }

        [Required]
        public int companyId { get; set; }

        [ForeignKey("companyId")]
        public Company company { get; set; }

      //  public ICollection<User> users { get; set; }       
 }   
}