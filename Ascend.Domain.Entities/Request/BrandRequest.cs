using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ascend.Domain.Entities.Request
{
    public class BrandCreateRequest
    {
        [Required(ErrorMessage = "brandName is required")]
        [StringLength(100)]
        public string brandName { get; set; }
        public string brandDescription { get; set; }
    }

    public class BrandEditRequest : BrandCreateRequest
    {
        [Required(ErrorMessage = "brandId is required")]
        public int brandId { get; set; }
    }
}