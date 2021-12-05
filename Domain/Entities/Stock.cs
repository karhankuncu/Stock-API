using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Stock : Entity
    {
      
        [Required]
        [MaxLength(100)]
        public string VariantCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductCode { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
