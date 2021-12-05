using System.ComponentModel.DataAnnotations;

namespace Stock_API.Dto
{
    public class StockDto
    {
        [Required]
        [MaxLength(100)]
        public string VariantCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductCode { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
